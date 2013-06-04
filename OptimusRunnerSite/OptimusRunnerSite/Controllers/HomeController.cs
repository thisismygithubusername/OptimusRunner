using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OptimusRunnerSite.Models;

namespace OptimusRunnerSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Testing(string testName, string testClass, string SiteID)
        {
            var model = new TestingModels.RunningTestModel
            {
                Name = testName,
                Class = testClass,
                SiteID = SiteID,
            };
            return View(model);
        }
    }
}
