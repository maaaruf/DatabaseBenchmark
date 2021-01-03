using DatabaseBenchmark.Domain.Entity;
using DatabaseBenchmark.Domain.Repositories;
using DatabaseBenchmark.Domain.Session;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseBenchmark.Domain.Service
{
    public class ProductService
    {
        public RandomDataGeneratorService _randomDataGenerator { get; set; }
        public ObjectToJsonConverterService _objectToJsonConverter { get; set; }
        public ProductsObjectRepository _jsonObjectRepository { get; set; }
        public ProductKeyRepository _productKeyRepository { get; set; }
        public ProductService()
        {
            _randomDataGenerator = new RandomDataGeneratorService();
            _objectToJsonConverter = new ObjectToJsonConverterService();
            _jsonObjectRepository = new ProductsObjectRepository(new DBBenchmarkMySqlSession());
            _productKeyRepository = new ProductKeyRepository(new LoadTestMySqlSession());
        }


        public IList<JsonObject> GenerateJsonProducts(int dataCount)
        {
            IList<JsonObject> ProductsInJson = new List<JsonObject>();

            while (dataCount > 0)
            {
                IList<Product> products = _randomDataGenerator.GenerateProducts(100);
                var product = new ProductsObject { Key = Guid.NewGuid().ToString(), Products = products };
                string json = _objectToJsonConverter.Convert(product);
                JsonObject productData = new JsonObject { ProductKey = product.Key, ProductValue = json };
                ProductsInJson.Add(productData);
                dataCount--;
            }

            return ProductsInJson;
        }

        public TimeSpan InsertProducts(IList<JsonObject> ProductsInJson)
        {
            DateTime startTime = DateTime.Now;

            _jsonObjectRepository.Add(ProductsInJson);

            DateTime endTime = DateTime.Now;
            TimeSpan SpendedTime = endTime.Subtract(startTime);

            return SpendedTime;
        }

        public JsonObject GetSingleKeysProduct(string key)
        {
            JsonObject data = _jsonObjectRepository.GetSingle(x => x.ProductKey == key);
            return data;
        }

        public void InsertKey(string key)
        {
            ProductKey productKey = new ProductKey { ProductsKey = key };
            _productKeyRepository.Add(productKey);
        }
    }
}
