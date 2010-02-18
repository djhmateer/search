using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace jquery.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Search(string searchTerm)
        {
            if (searchTerm == string.Empty)
            {
                return View();
            }
            else
            {
                // if the search contains only one result return details
                // otherwise a list
                var artists = from a in Db()
                              where a.Contains(searchTerm)
                              orderby a
                              select a;

                if (artists.Count() == 0)
                {
                    return View("notfound");
                }

                if (artists.Count() > 1)
                {
                    return View("List", artists);
                }
                else
                {
                    return RedirectToAction("Details", new {id = artists.First()});
                }
            }
        }

        public ActionResult Details(string id) {
            ViewData["Message"] = "You selected: " + id;
            return View();
        }

        public ActionResult getAjaxResult(string q)
        {
            string searchResult = string.Empty;

            var results = (from a in Db()
                           where a.Contains(q)
                           orderby a
                           select a).Take(10);

            foreach (string a in results)
            {
                searchResult += string.Format("{0}|\r\n", a);
            }

            return Content(searchResult);
        }

        IList<string> Db()
        {
            List<string> results = new List<string>();
            results.Add("apple");
            results.Add("advocado");
            results.Add("aardvark");
            results.Add("banana");
            results.Add("orange");
            return results;
        }
    }
}