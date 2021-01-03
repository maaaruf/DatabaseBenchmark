using DatabaseBenchmark.Domain.Entity;
using DatabaseBenchmark.Domain.Repositories;
using DatabaseBenchmark.Domain.Session;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseBenchmark.Domain.Service
{
    public class ProductService : IProductService
    {
        public RandomDataGeneratorService _randomDataGenerator { get; set; }
        public ObjectToJsonConverterService _objectToJsonConverter { get; set; }
        public ProductsObjectMongoRepository _productsObjectRepository { get; set; }
        public ProductKeyRepository _productKeyRepository { get; set; }
        public ProductService()
        {
            _randomDataGenerator = new RandomDataGeneratorService();
            _objectToJsonConverter = new ObjectToJsonConverterService();
            _productsObjectRepository = new ProductsObjectMongoRepository();
            _productKeyRepository = new ProductKeyRepository(new LoadTestMySqlSession());
        }


        public IList<ProductsObject> GenerateJsonProducts(int dataCount)
        {
            IList<ProductsObject> productsList = new List<ProductsObject>();

            IList<Product> products = _randomDataGenerator.GenerateProducts(100);

            while (dataCount > 0)
            {
                productsList.Add(new ProductsObject { Key = Guid.NewGuid().ToString(), Products = products });
                dataCount--;
            }

            return productsList;
        }

        public TimeSpan InsertProducts(IList<ProductsObject> products)
        {
            DateTime startTime = DateTime.Now;

            _productsObjectRepository.Add(products);

            DateTime endTime = DateTime.Now;
            TimeSpan SpendedTime = endTime.Subtract(startTime);

            return SpendedTime;
        }

        public ProductsObject GetSingleKeysProduct(string key)
        {
            var data = _productsObjectRepository.GetSingle(x => x.Key == key);
            return data;
        }

        public void InsertKey(string key)
        {
            ProductKey productKey = new ProductKey { ProductsKey = key };
            _productKeyRepository.Add(productKey);
        }
    }
}
