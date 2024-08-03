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