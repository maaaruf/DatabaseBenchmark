﻿using DatabaseBenchmark.Domain.Entity;
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
        public RandomDataGeneratorService _randomDataGenerator { get; set; }
        public ObjectToJsonConverterService _objectToJsonConverter { get; set; }
        public ProductsObjectRepository _jsonObjectRepository { get; set; }
        public ProductKeyRepository _productKeyRepository { get; set; }
        public ProductMongoService _productService { get; set; }
        public BaseModel()
        {
            _productService = new ProductMongoService();
            _randomDataGenerator = new RandomDataGeneratorService();
            _objectToJsonConverter = new ObjectToJsonConverterService();
            _jsonObjectRepository = new ProductsObjectRepository(new DBBenchmarkMySqlSession());
            _productKeyRepository = new ProductKeyRepository(new LoadTestMySqlSession());
        }
    }

}