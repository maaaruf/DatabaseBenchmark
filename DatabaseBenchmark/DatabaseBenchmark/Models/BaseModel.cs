using DatabaseBenchmark.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseBenchmark.Web.Models
{
    public class BaseModel
    {
        public RandomDataGeneratorService randomDataGenerator { get; set; }
        public ObjectToJsonConverterService ObjectToJsonConverter { get; set; }
        public BaseModel()
        {
            randomDataGenerator = new RandomDataGeneratorService();
            ObjectToJsonConverter = new ObjectToJsonConverterService();
        }
    }
}
