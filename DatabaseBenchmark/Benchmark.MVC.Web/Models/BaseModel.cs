using Autofac;
using DatabaseBenchmark.Domain.Entity;
using DatabaseBenchmark.Domain.Repositories;
using DatabaseBenchmark.Domain.Service;
using DatabaseBenchmark.Domain.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Benchmark.MVC.Web.Models
{
    public class BaseModel
    {
        public IRandomDataGeneratorService _randomDataGenerator { get; set; }
        public IObjectToJsonConverterService _objectToJsonConverter { get; set; }
        public IJsonToObjectConverterService<Product> _jsonToProductsObjectConverterService { get; set; }
        public IProductService _productService { get; set; }
        public BaseModel()
        {
            _productService = Startup.AutofacContainer.Resolve<IProductService>();
            _randomDataGenerator = Startup.AutofacContainer.Resolve<IRandomDataGeneratorService>();
            _objectToJsonConverter = Startup.AutofacContainer.Resolve<IObjectToJsonConverterService>();
            _jsonToProductsObjectConverterService = Startup.AutofacContainer.Resolve<IJsonToObjectConverterService<Product>>();
        }
    }

}