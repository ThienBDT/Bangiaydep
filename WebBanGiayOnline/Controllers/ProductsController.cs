using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanGiayOnline.Models;

namespace WebBanGiayOnline.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Products
        public ActionResult Index()
        {   
            var items = db.Products.ToList();           
            return View(items);
        }
        public ActionResult Detail(string alias, int id)
        {
            var items = db.Products.Find(id);
            // Truy vấn để chỉ lấy trường ColorCode
            var colorList = db.ProductDetails
                                   .Where(pd => pd.ProductId == id)
                                   .Select(pd => pd.ColorCode) // Chọn chỉ trường ColorCode
                                   .Distinct() // (Tùy chọn) Loại bỏ các giá trị trùng lặp nếu cần
                                   .ToList();
            // Lấy danh sách màu từ bảng Colors mà ColorCode nằm trong colorList
            var colors = db.Colors
                           .Where(c => colorList.Contains(c.ColorCode)) // Lọc dựa trên colorList
                           .ToList();

            // Truy vấn để chỉ lấy trường ColorCode
            var sizeList = db.ProductDetails
                                   .Where(pd => pd.ProductId == id)
                                   .Select(pd => pd.SizeId) // Chọn chỉ trường ColorCode
                                   .Distinct() // (Tùy chọn) Loại bỏ các giá trị trùng lặp nếu cần
                                   .ToList();
            var sizes = db.Sizes
                           .Where(c => sizeList.Contains(c.SizeId)) // Lọc dựa trên colorList
                           .ToList();
            //var sizes = db.Sizes.Find(id).ToList();


            ViewBag.Colors = new SelectList(colors, "ColorCode", "ColorName");
            ViewBag.Sizes = new SelectList(sizes, "SizeId", "SizeName");
            return View(items);
        }
        public ActionResult ProductGender(string alias, int? id)
        {

            var items = db.Products.ToList();
            if (id > 0)
            {
                items = items.Where(x => x.ProductGenderId == id).ToList();
            }
            var gen = db.ProductGenders.Find(id);
            if (gen != null)
            {
                ViewBag.GenName = gen.ProductGenderName;
            }
            ViewBag.GenId = id;

            return View(items);
        }

        public ActionResult Partial_ItemsByCateId()
        {
            var items = db.Products.Where(x => x.IsHome && x.IsActive).Take(12).ToList();
               return PartialView(items);
        }
        public ActionResult Partial_ProductSales()
        {
            var items = db.Products.Where(x => x.IsSale && x.IsActive).Take(12).ToList();
            return PartialView(items);
        }
    }
}