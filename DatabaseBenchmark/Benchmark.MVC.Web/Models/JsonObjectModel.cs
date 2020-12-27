using DatabaseBenchmark.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benchmark.MVC.Web.Models
{
    public class JsonObjectModel : BaseModel
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public int JsonDataCount { get; set; }
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
                ProductsObjectInJson.Add(new JsonObject { Key = item.Key, Value = json });
            }
        }
    }
}
