using DatabaseBenchmark.Domain.Entity;
using DatabaseBenchmark.Domain.Mappings;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Benchmark.MVC.Web.Models
{
    public class JsonObjectModel : BaseModel
    {
        public string Key { get; set; }
        public string Value { get; set; }
        [DisplayName("Data Count")]
        public int JsonDataCount { get; set; }
        public TimeSpan TotalSpendedTime { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public IList<JsonObject> ProductsObjectInJson { get; set; }

        public void GenerateAndInsertData()
        {
            var productsInJson = _productService.GenerateJsonProducts(JsonDataCount);

            StartTime = DateTime.Now;
            TotalSpendedTime = _productService.InsertProducts(productsInJson);
            EndTime = DateTime.Now;
        }
    }
}
