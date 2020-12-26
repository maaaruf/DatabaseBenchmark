using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseBenchmark.Web.Models
{
    public class ObjectToJsonConverver
    {
        public string JsonConverter(object rawObject)
        {
            string json = JsonConvert.SerializeObject(rawObject);
            return json;
        }
    }
}
