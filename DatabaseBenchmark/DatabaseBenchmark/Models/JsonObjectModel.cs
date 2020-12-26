using DatabaseBenchmark.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseBenchmark.Web.Models
{
    public class JsonObjectModel : BaseModel
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public int JsonDataCount { get; set; }
        public IList<JsonObject> Jsons { get; set; }
        public IList<JsonObject> productsInJson { get; set; }


        public void generateProductsJsonData()
        {
            Jsons = _jsonDataGenerator.generateJsonData(JsonDataCount);
        }


        public void generateProductsJsonsJsonData()
        {
            IList<JsonObject> jsonsProduct = _jsonDataGenerator.generateJsonData(JsonDataCount);
            productsInJson = new List<JsonObject>();

            foreach(var item in jsonsProduct)
            {
                var data =  _objectToJsonConverter.JsonConverter(item);
                productsInJson.Add(new JsonObject { 
                    Key = Guid.NewGuid().ToString(),
                    Value = data
                });
            }
            //string keyValueProducts = _objectToJsonConverter.JsonConverter(jsonsProduct);
        }
    }
}
