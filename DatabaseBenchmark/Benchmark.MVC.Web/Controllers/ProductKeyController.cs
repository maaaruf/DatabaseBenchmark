using Benchmark.MVC.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Benchmark.MVC.Web.Controllers
{
    public class ProductKeyController : Controller
    {
        // GET: ProductKey
        public ActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Index(ProductKeyModel model)
        {
            if (ModelState.IsValid)
                model.InsertProductKey(model.productKey);

            return View();
        }
    }
}