using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanGiayOnline.Models;
using WebBanGiayOnline.Models.EF;

namespace WebBanGiayOnline.Areas.Admin.Controllers
{
    public class ProductGenderController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/ProductGender
        public ActionResult Index()
        {
            var items = db.ProductGenders;
            return View(items);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Models.EF.ProductGender model)
        {
            if (ModelState.IsValid)
            {
                var existingGender = db.ProductGenders.FirstOrDefault(x => x.ProductGenderName == model.ProductGenderName);
                if (existingGender != null)
                {
                    ModelState.AddModelError("", "Đối tượng người dùng sản phẩm này đã tồn tại.");
                    return View(model);
                }
                model.CreatedDate = DateTime.Now;
                model.ModifiedDate = DateTime.Now;
                model.Alias = WebBanGiayOnline.Models.Common.Filter.FilterChar(model.ProductGenderName);
                db.ProductGenders.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Edit(int id)
        {
            var item = db.ProductGenders.Find(id);

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.EF.ProductGender model)
        {
            if (ModelState.IsValid)
            {
                model.ModifiedDate = DateTime.Now;
                model.Alias = WebBanGiayOnline.Models.Common.Filter.FilterChar(model.ProductGenderName);
                db.ProductGenders.Attach(model);
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.ProductGenders.Find(id);
            if (item != null)
            {
                db.ProductGenders.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
        [HttpPost]
        public ActionResult DeleteAll(string ids)
        {
            if (!string.IsNullOrEmpty(ids))
            {
                var items = ids.Split(',');
                if (items != null && items.Any())
                {
                    foreach (var item in items)
                    {
                        var obj = db.ProductGenders.Find(Convert.ToInt32(item));
                        db.ProductGenders.Remove(obj);
                        db.SaveChanges();
                    }
                }
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}