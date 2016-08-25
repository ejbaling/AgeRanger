using AgeRanger.Repository;
using System.Linq;
using System.Web.Mvc;
using AgeRanger.Models;

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

        public string AddItem(Person p)
        {
            if (p != null)
            {
                using (var dataContext = new AgeRangerContext())
                {
                    dataContext.People.Add(p);
                    dataContext.SaveChanges();
                    return "Person added.";
                }
            }
            else
            {
                return "Invalid Person.";
            }
        }

    }
}
