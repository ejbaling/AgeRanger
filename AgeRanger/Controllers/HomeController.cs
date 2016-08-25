using AgeRanger.Repository;
using System.Linq;
using System.Web.Mvc;

namespace AgeRanger.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetItems()
        {
            using (var dataContext = new AgeRangerContext())
            {
                var items = dataContext.People.ToArray();
                return Json(items, JsonRequestBehavior.AllowGet);
            }
        }

    }
}
