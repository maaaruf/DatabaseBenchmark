using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseBenchmark.Domain.Entity
{
    public class JsonProductsObject
    {
        public string Key { get; set; }
        IList<JsonProducts> Products { get; set; }
    }
}
