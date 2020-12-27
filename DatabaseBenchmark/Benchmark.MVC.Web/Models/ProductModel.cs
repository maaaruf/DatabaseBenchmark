using DatabaseBenchmark.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benchmark.MVC.Web.Models
{
    public class ProductModel : BaseModel
    {
        

        public int productCount { get; set; }
        public string Tittle { get; set; }
        public string Brand { get; set; }
        public double Price { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public IList<Product> Products { get; set; }
        public IList<JsonObject> Jsons { get; set; }

        public IList<Product> generateProduct()
        {
            productCount = 50;
            return _randomDataGenerator.generateProducts(productCount);
        }


        public void generateJsonData(int count)
        {
            Jsons = new List<JsonObject>();

            while (count > 0)
            {
                var products = generateProduct();
                string data = _objectToJsonConverter.JsonConverter(products);
                JsonObject jsonObject = new JsonObject { ProductKey = "  " +"Key - " + Guid.NewGuid(), ProductValue = data };
                Jsons.Add(jsonObject);
                count--;
            }
        }
    }
}
