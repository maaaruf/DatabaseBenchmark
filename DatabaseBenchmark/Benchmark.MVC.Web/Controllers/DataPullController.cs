using Benchmark.MVC.Web.Models;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using System.Text;
using System.Net;
using System.Net.Http;
using DatabaseBenchmark.Domain.Entity;
using log4net;

namespace Benchmark.MVC.Web.Controllers
{
    public class DataPullController : Controller
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(DataPullController));
        // GET: DataPull
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(DataPullModel model)
        {
            var data = model.PullData(model.Key);

            //Log.Error($"Time taken : {model.TotalSpendedTime}");

            //if (data == null || data == "")
            //    return Json("null");

            //var json = JsonSerializer.Deserialize<JsonProducts>(data);

            return Json(data);
        }
    }
}