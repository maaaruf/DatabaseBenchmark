using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseBenchmark.Domain.Entity
{
    public class JsonProducts
    {
        public string Key { get; set; }
        public IList<Product> Products { get; set; }
    }
}
