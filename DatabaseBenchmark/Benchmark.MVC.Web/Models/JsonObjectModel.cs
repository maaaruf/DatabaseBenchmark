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
        public bool ShowDuration = false;
        public IList<JsonObject> ProductsObjectInJson { get; set; }



        public void GenerateAndInsertDataBySplit()
        {
            StartTime = DateTime.Now;
            while (JsonDataCount > 0)
            {
                
                TotalSpendedTime += GenerateAndInsertData(100);
                JsonDataCount -= 100;

                if (JsonDataCount < 100 && JsonDataCount > 0)
                {
                    TotalSpendedTime += GenerateAndInsertData(JsonDataCount);
                    break;
                }
            }
            EndTime = DateTime.Now;
            ShowDuration = true;
        }


        public TimeSpan GenerateAndInsertData(int count)
        {
            var productsInJson = _productService.GenerateJsonProducts(count);
            
            TimeSpan SpendedTime = _productService.InsertProducts(productsInJson);
            

            return SpendedTime;
        }
    }
}
