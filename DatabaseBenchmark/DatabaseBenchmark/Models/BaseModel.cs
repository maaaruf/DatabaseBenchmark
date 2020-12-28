using DatabaseBenchmark.Domain.Service;
using DatabaseBenchmark.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseBenchmark.Web.Models
{
    public class BaseModel
    {
        public RandomDataGeneratorService _randomDataGenerator { get; set; }
        public ObjectToJsonConverterService _objectToJsonConverter { get; set; }
        public BaseModel()
        {
            _randomDataGenerator = new RandomDataGeneratorService();
            _objectToJsonConverter = new ObjectToJsonConverterService();
        }
    }
}
