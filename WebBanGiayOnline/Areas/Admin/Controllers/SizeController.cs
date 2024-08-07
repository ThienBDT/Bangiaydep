﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanGiayOnline.Models;

namespace WebBanGiayOnline.Areas.Admin.Controllers
{
    public class SizeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Size
        public ActionResult Index()
        {
            var items = db.Sizes;
            return View(items);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Models.EF.Size model)
        {
            if (ModelState.IsValid)
            {
                var existingGender = db.Sizes.FirstOrDefault(x => x.SizeName == model.SizeName);
                if (existingGender != null)
                {
                    ModelState.AddModelError("", "Kích thước này đã tồn tại.");
                    return View(model);
                }
                db.Sizes.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Edit(int id)
        {
            var item = db.Sizes.Find(id);

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.EF.Size model)
        {
            if (ModelState.IsValid)
            {
                db.Sizes.Attach(model);
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.Sizes.Find(id);
            if (item != null)
            {
                db.Sizes.Remove(item);
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
                        var obj = db.Sizes.Find(Convert.ToInt32(item));
                        db.Sizes.Remove(obj);
                        db.SaveChanges();
                    }
                }
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}