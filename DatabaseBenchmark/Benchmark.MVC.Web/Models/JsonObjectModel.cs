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
        public TimeSpan SpendedTime { get; set; }
        public IList<JsonObject> ProductsObjectInJson { get; set; }


        public void generateJson()
        {
            IList<JsonProducts> jsonProducts = new List<JsonProducts>();
            ProductsObjectInJson = new List<JsonObject>();

            while (JsonDataCount > 0)
            {
                IList<Product> products = _randomDataGenerator.generate50Products();
                jsonProducts.Add(new JsonProducts { Key = Guid.NewGuid().ToString(), Products = products });
                JsonDataCount--;
            }

            foreach(var item in jsonProducts)
            {
                string json = _objectToJsonConverter.JsonConverter(item);
                JsonObject productData =  new JsonObject { ProductKey = item.Key, ProductValue = json };
                ProductsObjectInJson.Add(productData);
            }

            DateTime startTime = DateTime.Now;

            foreach (var item in ProductsObjectInJson)
            {
                _jsonObjectRepository.Add(new JsonObject { ProductKey = item.ProductKey, ProductValue = item.ProductValue });
            }

            DateTime endTime = DateTime.Now;

           // TimeSpan duration = DateTime.Parse(time.endTime).Subtract(DateTime.Parse(time.startTime));
            SpendedTime = endTime.Subtract(startTime);


        }

    }
}
