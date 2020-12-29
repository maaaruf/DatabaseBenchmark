using DatabaseBenchmark.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Benchmark.MVC.Web.Models
{
    public class ProductKeyModel : BaseModel
    {
        public string productKey { get; set; }

        public void InsertProductKey(string key)
        {
            _productService.InsertKey(key);
        }
    }
}