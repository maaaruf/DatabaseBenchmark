using DatabaseBenchmark.Models;
using DatabaseBenchmark.Web.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseBenchmark.Web.Models
{
    public class ProductModel
    {

        public int productCount { get; set; }
        public string Tittle { get; set; }
        public string Brand { get; set; }
        public double Price { get; set; }
        public IList<Product> Products { get; set; }
        public IList<JsonObject> Jsons { get; set; }

        public RandomDataGenerator dataGenerator = new RandomDataGenerator();

        
        public IList<Product> generateProduct()
        {
            productCount = 50;
            return dataGenerator.generateProducts(productCount);
        }


        public void generateJsonData(int count)
        {
            ObjectToJsonConverver objectToJsonConverver = new ObjectToJsonConverver();

            while (count > 0)
            {
                string data = objectToJsonConverver.JsonConverter(generateProduct());
                JsonObject jsonObject = new JsonObject { Key = "Key - " + Guid.NewGuid(), Value = data };
                Jsons.Add(jsonObject);
            }

        }
    }
}
