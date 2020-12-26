using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseBenchmark.Domain.Service
{
    public class ObjectToJsonConverterService
    {
        public string JsonConverter(object rawObject)
        {
            string json = JsonConvert.SerializeObject(rawObject);
            return json;
        }
    }
}
