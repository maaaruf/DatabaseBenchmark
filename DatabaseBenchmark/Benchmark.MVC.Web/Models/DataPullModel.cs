using DatabaseBenchmark.Domain.Entity;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

namespace Benchmark.MVC.Web.Models
{
    public class DataPullModel : BaseModel
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public IList<JsonObject> ProductsObjectInJson { get; set; }
        public string PullData(string key)
        {
            JsonObject data = _jsonObjectRepository.GetSingle(x=>x.ProductKey==key);

            if (data == null)
                return "null";
            else
                return data.ProductValue;
        }
    }
}