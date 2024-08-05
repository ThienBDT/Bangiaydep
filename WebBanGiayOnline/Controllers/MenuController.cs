using System.Linq;
using System.Web.Mvc;
using WebBanGiayOnline.Models;

namespace WebBanGiayOnline.Controllers
{
    public class MenuController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MenuTop()
        {
            var items = db.Categories.OrderBy(x => x.Position).ToList();
            return PartialView("_MenuTop", items);
        }
        public ActionResult MenuProductGender()
        {
            var items = db.ProductGenders.ToList();
            return PartialView("_MenuProductGender", items);
        }
        public ActionResult MenuLeft(int? id)
        {
            if (id != null)
            {
                ViewBag.GenId = id;
            }
            var items = db.ProductGenders.OrderBy(x => x.Id).ToList();
            return PartialView("_MenuLeft", items);
        }
        public ActionResult MenuArrivals()
        {
            var items = db.ProductGenders.ToList();
            return PartialView("_MenuArrivals", items);
        }

    }
}