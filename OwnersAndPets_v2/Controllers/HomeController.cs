using System.Web.Mvc;

namespace OwnersAndPets_v2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Owners and Pets";

            return View();
        }

        public ActionResult OwnerDetail(int id)
        {
            ViewBag.Title = "Owner detail";

            return View(id);
        }
    }
}
