using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanGiayOnline.Areas.Admin.ViewModels;
using WebBanGiayOnline.Models;
using WebBanGiayOnline.Models.EF;
using System.Data.Entity;
using System.Threading.Tasks;
using ProductDetailViewModel = WebBanGiayOnline.Areas.Admin.ViewModels.ProductDetailViewModel;

namespace WebBanGiayOnline.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Products
        public ActionResult Index(int? page)
        {
            IEnumerable<Product> items = db.Products.OrderByDescending(x => x.ProductId);
            // Strart Tạo phân trang trong quản lý danh sách sản phẩm 
            var pageSize = 6;
            if (page == null)
            {
                page = 1;
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            // End Tạo phân trang trong quản lý danh sách sản phẩm
            return View(items);
        }
        public ActionResult Add()
        {
            var viewModel = new ProductViewModel
            {
                Product = new Product(),
                ProductDetails = new List<ProductDetailViewModel>() 
            };
            ViewBag.ProductCategory = new SelectList(db.ProductCategories.ToList(), "Id", "ProductCategoryName");
            ViewBag.ProductGender = new SelectList(db.ProductGenders.ToList(), "Id", "ProductGenderName");
            ViewBag.Colors = new SelectList(db.Colors, "ColorCode", "ColorName");
            ViewBag.Sizes = new SelectList(db.Sizes, "SizeId", "SizeName");
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ProductViewModel viewModel, List<string> Images, int[] rDefault)
        {
            if (ModelState.IsValid)
            {
                var existingProduct = db.Products.FirstOrDefault(x => x.ProductCode == viewModel.Product.ProductCode);
                if (existingProduct != null)
                {
                    ModelState.AddModelError("", "Mã sản phẩm này đã tồn tại này đã tồn tại.");
                    return View(viewModel);
                }
                // Lưu ảnh mặc định vào sản phẩm nếu có
                if (Images != null && Images.Count > 0)
                {
                    for (int i = 0; i < Images.Count; i++)
                    {
                        bool isDefault = (rDefault != null && rDefault.Length > 0 && i + 1 == rDefault[0]);
                        if (isDefault)
                        {
                            viewModel.Product.Image = Images[i];
                        }

                        var productdetailimage = new ProductDetailImage
                        {
                            ProductId = viewModel.Product.ProductId,
                            Image = Images[i],
                            IsDefault = isDefault
                        };
                        db.ProductDetailImages.Add(productdetailimage);
                    }
                }
                else
                {
                    return View(viewModel);
                }
                viewModel.Product.CreatedDate = DateTime.Now;
                viewModel.Product.Alias = WebBanGiayOnline.Models.Common.Filter.FilterChar(viewModel.Product.ProductName);
                db.Products.Add(viewModel.Product);
                db.SaveChanges();
                foreach (var detail in viewModel.ProductDetails)
                {
                    var productDetail = new ProductDetail
                    {
                        ProductId = viewModel.Product.ProductId,
                        ColorCode = detail.ColorCode,
                        SizeId = detail.SizeId,
                        Stock = detail.Stock
                    };
                    db.ProductDetails.Add(productDetail);
                }
                viewModel.CreatedDate = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.ProductCategory = new SelectList(db.ProductCategories.ToList(), "Id", "ProductCategoryName");
            //ViewBag.ProductGender = new SelectList(db.ProductGenders.ToList(), "Id", "ProductGenderName");
            //ViewBag.Colors = new SelectList(db.Colors, "ColorCode", "ColorName");
            //ViewBag.Sizes = new SelectList(db.Sizes, "SizeId", "SizeName");
            return View(viewModel);
        }
        // get
        public ActionResult GetEdit(int id, ProductViewModel viewModel)
        {
            var item = db.Products.Find(id);
          
            viewModel.Product = new Product();
            viewModel.Product.ProductName = item.ProductName;
            viewModel.Product.Detail = item.Detail;
            viewModel.Product.Description = item.Description;
            viewModel.Product.Quantity = item.Quantity;
            viewModel.Product.PriceSale = item.PriceSale;
            viewModel.Product.Price = item.Price;
            viewModel.Product.ProductCode = item.ProductCode;
            viewModel.Product.ProductName = item.ProductName;
            viewModel.Product.IsActive = item.IsActive;
            viewModel.Product.IsHome = item.IsHome;
            viewModel.Product.IsSale = item.IsSale;
            viewModel.Product.IsFeature = item.IsFeature;
            viewModel.Product.ProductCategoryId = item.ProductCategoryId;
            viewModel.Product.ProductGenderId = item.ProductGenderId;           
            viewModel.ProductDetails = db.ProductDetails.Where(pd => pd.ProductId == item.ProductId).Select(pd => new ProductDetailViewModel
                                         {
                                            ProductDetailId = pd.ProductDetailId,
                                            ColorCode = pd.ColorCode,
                                            SizeId = pd.SizeId,
                                            Stock = pd.Stock,                                     
                                 }).ToList();
            //foreach (var detail in viewModel.ProductDetails)
            //{
            //    var productDetail = new ProductDetail
            //    {
            //        ProductId = viewModel.Product.ProductId,
            //        ColorCode = detail.ColorCode,
            //        SizeId = detail.SizeId,
            //        Stock = detail.Stock
            //    };
            //    db.ProductDetails.Add(productDetail);
            //}
            ViewBag.ProductCategory = new SelectList(db.ProductCategories.ToList(), "Id", "ProductCategoryName");
            ViewBag.ProductGender = new SelectList(db.ProductGenders.ToList(), "Id", "ProductGenderName");
            ViewBag.Colors = new SelectList(db.Colors, "ColorCode", "ColorName");
            ViewBag.Sizes = new SelectList(db.Sizes, "SizeId", "SizeName");
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductViewModel viewModel)
        {
            
            if (ModelState.IsValid)
            {
                var existingProduct = db.Products.FirstOrDefault(x => x.ProductCode == viewModel.Product.ProductCode);
                if (existingProduct != null)
                {
                    ModelState.AddModelError("", "Mã sản phẩm này đã tồn tại này đã tồn tại.");
                    return View(viewModel);
                }

                var item = db.Products.First(p => p.ProductId == viewModel.Product.ProductId);

                item.ProductName = viewModel.Product.ProductName;
                item.ProductCode = viewModel.Product.ProductCode;
                item.Detail = viewModel.Product.Detail;
                item.Description = viewModel.Product.Description;
                item.Price = viewModel.Product.Price;
                item.PriceSale = viewModel.Product.PriceSale;
                item.Quantity = viewModel.Product.Quantity;
                item.IsActive = viewModel.Product.IsActive;
                item.IsHome = viewModel.Product.IsHome;
                item.IsFeature = viewModel.Product.IsFeature;
                item.IsHot = viewModel.Product.IsHot;
                item.IsSale = viewModel.Product.IsSale;
                item.ProductCategoryId = viewModel.Product.ProductCategoryId;
                item.ProductGenderId = viewModel.Product.ProductGenderId;

                item.ProductDetails.Clear();
                if(viewModel.ProductDetails != null)
                {
                    foreach(var detail in viewModel.ProductDetails)
                    {
                        var productDetail = new ProductDetail
                        {
                            ProductId = viewModel.Product.ProductId,
                            ColorCode = detail.ColorCode,
                            SizeId = detail.SizeId,
                            Stock = detail.Stock
                        };
                        db.ProductDetails.Add(productDetail);
                    }
                }
                
                viewModel.ModifiedDate = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            viewModel.Product.CreatedDate = DateTime.Now;
            viewModel.Product.Alias = WebBanGiayOnline.Models.Common.Filter.FilterChar(viewModel.Product.ProductName);
            //ViewBag.ProductCategory = new SelectList(db.ProductCategories.ToList(), "Id", "ProductCategoryName");
            //ViewBag.ProductGender = new SelectList(db.ProductGenders.ToList(), "Id", "ProductGenderName");
            //ViewBag.Colors = new SelectList(db.Colors, "ColorCode", "ColorName");
            //ViewBag.Sizes = new SelectList(db.Sizes, "SizeId", "SizeName");
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult IsActive(int id)
        {
            var item = db.Products.Find(id);
            if (item != null)
            {
                item.IsActive = !item.IsActive;
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true, isActive = item.IsActive });
            }
            return Json(new { success = false });
        }
        [HttpPost]
        public ActionResult IsHome(int id)
        {
            var item = db.Products.Find(id);
            if (item != null)
            {
                item.IsHome = !item.IsHome;
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true, isActive = item.IsActive });
            }
            return Json(new { success = false });
        }
        [HttpPost]
        public ActionResult IsSale(int id)
        {
            var item = db.Products.Find(id);
            if (item != null)
            {
                item.IsSale = !item.IsSale;
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true, isActive = item.IsActive });
            }
            return Json(new { success = false });
        }
    }
}
