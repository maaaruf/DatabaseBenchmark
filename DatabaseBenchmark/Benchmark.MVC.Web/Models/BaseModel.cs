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
        public RandomDataGeneratorService _randomDataGenerator { get; set; }
        public ObjectToJsonConverterService _objectToJsonConverter { get; set; }
        public Repository<JsonObject, DBBenchmarkMySqlSession> _jsonObjectRepository { get; set; }
        public BaseModel()
        {
            _randomDataGenerator = new RandomDataGeneratorService();
            _objectToJsonConverter = new ObjectToJsonConverterService();
            _jsonObjectRepository = new Repository<JsonObject, DBBenchmarkMySqlSession>(new DBBenchmarkMySqlSession());
        }
    }

}