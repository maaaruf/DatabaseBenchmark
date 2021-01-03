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
        public IRandomDataGeneratorService _randomDataGenerator { get; set; }
        public IObjectToJsonConverterService _objectToJsonConverter { get; set; }
        public IProductsObjectRepository _productsObjectRepository { get; set; }
        public IProductKeyRepository _productKeyRepository { get; set; }
        public ProductService(
            IProductsObjectRepository productsObjectRepository,
            IRandomDataGeneratorService randomDataGeneratorService,
            IObjectToJsonConverterService objectToJsonConverterService,
            IProductKeyRepository productKeyRepository)
        {
            _randomDataGenerator = randomDataGeneratorService;
            _objectToJsonConverter = objectToJsonConverterService;
            _productsObjectRepository = productsObjectRepository;
            _productKeyRepository = productKeyRepository;
        }


        public IList<ProductsObject> GenerateJsonProducts(int dataCount)
        {
            IList<ProductsObject> productsList = new List<ProductsObject>();

            IList<Product> products = _randomDataGenerator.GenerateProducts(100);

            while (dataCount > 0)
            {
                string jsonProducts = _objectToJsonConverter.Convert(products);
                productsList.Add(new ProductsObject { ProductKey = Guid.NewGuid().ToString(), Products = products, ProductValue = jsonProducts });
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
            var data = _productsObjectRepository.GetSingle(x => x.ProductKey == key);
            return data;
        }

        public void InsertKey(string key)
        {
            ProductKey productKey = new ProductKey { ProductsKey = key };
            _productKeyRepository.Add(productKey);
        }
    }
}
