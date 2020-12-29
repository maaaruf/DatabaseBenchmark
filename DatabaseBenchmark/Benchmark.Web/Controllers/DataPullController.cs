using Benchmark.Web.Models;
using DatabaseBenchmark.Domain.Entity;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Benchmark.Web.Controllers
{
    public class DataPullController : Controller
    {
        // GET: DataPull
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(DataPullModel model)
        {
            string data = model.PullData(model.Key);
            //Log.Error($"Time taken : {model.TotalSpendedTime}");

            if (data == null)
                return Json("null");

            var json = JsonSerializer.Deserialize<JsonProducts>(data);
            return Json(json);
        }
    }
}