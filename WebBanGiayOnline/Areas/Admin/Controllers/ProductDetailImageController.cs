using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanGiayOnline.Models;
using WebBanGiayOnline.Models.EF;

namespace WebBanGiayOnline.Areas.Admin.Controllers
{
    public class ProductDetailImageController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/ProductImage
        // Thuộc tính tĩnh để lưu ID
        public class LuuThongTin
        {
            static public int Id = 0;
        }
        public ActionResult Index(int id)
        {
            ViewBag.ProducId = id;
            LuuThongTin.Id = id;
            var items = db.ProductDetailImages.Where(x=>x.ProductId == id).ToList();
            return View(items);
        }
        [HttpPost]
        public ActionResult AddImage( string url)
        {
           db.ProductDetailImages.Add(new ProductDetailImage {           
                ProductId = LuuThongTin.Id,
                Image = url,
                IsDefault = false
            });            
            db.SaveChanges();
            return Json(new { Success = true });
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.ProductDetailImages.Find(id);
            db.ProductDetailImages.Remove(item);
            db.SaveChanges();
            return Json(new { success = true });
        }
    }
}