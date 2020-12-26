using DatabaseBenchmark.Domain.Service;
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
        public JsonDataGeneratorService _jsonDataGenerator { get; set; }
        public BaseModel()
        {
            _randomDataGenerator = new RandomDataGeneratorService();
            _objectToJsonConverter = new ObjectToJsonConverterService();
            _jsonDataGenerator = new JsonDataGeneratorService();
        }
    }

}