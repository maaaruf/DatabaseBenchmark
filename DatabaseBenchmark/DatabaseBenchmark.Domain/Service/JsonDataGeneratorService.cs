using DatabaseBenchmark.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseBenchmark.Domain.Service
{
    public class JsonDataGeneratorService
    {

        public IList<JsonObject> ProductsInJsons { get; set; }
        public ObjectToJsonConverterService  _objectToJsonConverter { get; set; }
        public RandomDataGeneratorService _randomDataGenerator { get; set; }
        public JsonDataGeneratorService()
        {
            _objectToJsonConverter = new ObjectToJsonConverterService();
            _randomDataGenerator = new RandomDataGeneratorService();
        }

        public IList<JsonObject> generateJsonData(int count)
        {
            ProductsInJsons = new List<JsonObject>();

            while (count > 0)
            {
                IList<Product> products = _randomDataGenerator.generate50Products();
                string productsInJson = _objectToJsonConverter.JsonConverter(products);

                if (productsInJson != null)
                {
                    JsonObject jsonObject = new JsonObject { 
                        ProductKey = $"{products.FirstOrDefault().Id} {products.Last().Id}",
                        ProductValue = productsInJson 
                    };

                    ProductsInJsons.Add(jsonObject);
                }
                count--;
            }
            return ProductsInJsons;
        }

        
    }
}
