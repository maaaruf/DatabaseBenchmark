using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseBenchmark.Domain.Service
{
    public class ObjectToJsonConverterService : IObjectToJsonConverterService
    {
        public string Convert(object rawObject)
        {
            string json = JsonSerializer.Serialize(rawObject);

            return json;
        }
    }
}
