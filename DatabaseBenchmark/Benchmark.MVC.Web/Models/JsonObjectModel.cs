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
            var productsInJson = GenerateJsonProducts(JsonDataCount);

            StartTime = DateTime.Now;
            TotalSpendedTime = InsertProducts(productsInJson);
            EndTime = DateTime.Now;
        }

        public IList<JsonObject> GenerateJsonProducts(int dataCount)
        {
            IList<JsonObject> ProductsInJson = new List<JsonObject>();
            IList<JsonProducts> Products = new List<JsonProducts>();

            while (dataCount > 0)
            {
                IList<Product> products = _randomDataGenerator.GenerateProducts(100);
                Products.Add(new JsonProducts { Key = Guid.NewGuid().ToString(), Products = products });
                dataCount--;
            }

            foreach (var item in Products)
            {
                string json = _objectToJsonConverter.Convert(item);
                JsonObject productData = new JsonObject { ProductKey = item.Key, ProductValue = json };
                ProductsInJson.Add(productData);
            }

            return ProductsInJson;
        }

        TimeSpan InsertProducts(IList<JsonObject> ProductsInJson)
        {
            DateTime startTime = DateTime.Now;

            _jsonObjectRepository.Add(ProductsInJson);

            DateTime endTime = DateTime.Now;
            TimeSpan SpendedTime = endTime.Subtract(startTime);

            return SpendedTime;
        }


    }
}
