using AgeRanger.Models;
using AgeRanger.Repository;
using System;
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

        public JsonResult GetItems(string searchTerm)
        {
            using (var dataContext = new AgeRangerContext())
            {
                var people = dataContext.People.AsQueryable();
                var ageGroups = dataContext.AgeGroups.AsQueryable();

                var result = from p in people
                    from a in ageGroups
                    where
                        (p.Age >= a.MinAge || a.MinAge == null || (a.MinAge*1) == 0) &&
                        (p.Age < a.MaxAge || a.MaxAge == null || (a.MaxAge*1) == 0)
                    select
                        new
                        {
                            Id = p.Id,
                            FirstName = p.FirstName,
                            LastName = p.LastName,
                            Age = p.Age,
                            Description = a.Description
                        };

                if (!String.IsNullOrWhiteSpace(searchTerm))
                {
                    result =
                        result.Where(
                            p =>
                                p.FirstName.ToLower().Contains(searchTerm.ToLower()) ||
                                p.LastName.ToLower().Contains(searchTerm.ToLower()));
                }

                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
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
