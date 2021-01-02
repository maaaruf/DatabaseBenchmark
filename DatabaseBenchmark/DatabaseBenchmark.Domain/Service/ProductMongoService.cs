using DatabaseBenchmark.Domain.Entity;
using DatabaseBenchmark.Domain.Repositories;
using DatabaseBenchmark.Domain.Session;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseBenchmark.Domain.Service
{
    public class ProductMongoService
    {
        public RandomDataGeneratorService _randomDataGenerator { get; set; }
        public ObjectToJsonConverterService _objectToJsonConverter { get; set; }
        public RepositoryMongo<JsonProducts, DBBenchmarkMongoSession> _jsonObjectRepository { get; set; }
        public ProductMongoService()
        {
            _randomDataGenerator = new RandomDataGeneratorService();
            _objectToJsonConverter = new ObjectToJsonConverterService();
            _jsonObjectRepository = new RepositoryMongo<JsonProducts, DBBenchmarkMongoSession>(new DBBenchmarkMongoSession("dbb"),"products");
        }


        public JsonProducts GenerateJsonProducts(int dataCount)
        {
            IList<Product> products = _randomDataGenerator.GenerateProducts(100);
            var product = new JsonProducts { Key = Guid.NewGuid().ToString(), Products = products };

            return product;
        }


        public TimeSpan InsertProducts(JsonProducts products)
        {
            DateTime startTime = DateTime.Now;

            _jsonObjectRepository.Add(products);

            DateTime endTime = DateTime.Now;
            TimeSpan SpendedTime = endTime.Subtract(startTime);

            return SpendedTime;
        }

        public JsonProducts GetSingleKeysProduct(string key)
        {
            var data = _jsonObjectRepository.GetSingle(x => x.Key == key);
            return data;
        }


        public void InsertKey(string key)
        {
            ProductKey productKey = new ProductKey { ProductsKey = key };
            //_productKeyRepository.Add(productKey);
        }

    }
}
