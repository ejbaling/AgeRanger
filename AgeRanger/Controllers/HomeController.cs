using AgeRanger.Models;
using AgeRanger.Repository;
using System;
using System.Linq;
using System.Web.Mvc;
using AgeRanger.Service;

namespace AgeRanger.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetItems(string searchTerm)
        {
            var useCase = new GetItemUseCase();
            return Json(useCase.Execute(searchTerm).ToArray(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetItem(int id)
        {
            using (var dataContext = new AgeRangerContext())
            {
                var item = dataContext.People.FirstOrDefault(p => p.Id == id);
                return Json(item, JsonRequestBehavior.AllowGet);
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

        public string UpdateItem(Person person)
        {
            if (person != null)
            {
                using (var dataContext = new AgeRangerContext())
                {
                    var p = dataContext.People.FirstOrDefault(e => e.Id == person.Id);
                    if (p == null)
                    {
                        return "Invalid person.";
                    }
                    p.FirstName = person.FirstName;
                    p.LastName = person.LastName;
                    p.Age = person.Age;
                    dataContext.SaveChanges();
                    return "Person updated.";
                }
            }
            else
            {
                return "Invalid person.";
            }
        }
    }
}
