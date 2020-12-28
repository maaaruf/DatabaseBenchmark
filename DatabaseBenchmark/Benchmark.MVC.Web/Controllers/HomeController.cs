using Benchmark.MVC.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Benchmark.MVC.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            JsonObjectModel model = new JsonObjectModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(JsonObjectModel model)
        {
            if (ModelState.IsValid)
            {
                model.GenerateJson();
            }

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}