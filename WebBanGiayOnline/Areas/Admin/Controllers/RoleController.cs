using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanGiayOnline.Models;
using WebBanGiayOnline.Areas.Filters;

namespace WebBanGiayOnline.Areas.Admin.Controllers
{
    public class RoleController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Role
        public ActionResult Index()
        {
            var items = db.Roles.ToList();
            return View(items);
        }
        [CustomAuthorize(Roles = "Quản lý")]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IdentityRole model)
        {
            if (ModelState.IsValid)
            {
                var existingRole = db.Roles.FirstOrDefault(x => x.Name == model.Name);
                if (existingRole != null)
                {
                    ModelState.AddModelError("", "Quyền này đã tồn tại.");
                    return View(model);
                }
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
                roleManager.Create(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        //public ActionResult Edit(int Id)
        //{
        //    var item = db.Roles.Find(Id);
        //    return View(item);
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(IdentityRole model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
        //        roleManager.Create(model);
        //        return RedirectToAction("Index");
        //    }          
        //    return View(model);
        //}
    }
}