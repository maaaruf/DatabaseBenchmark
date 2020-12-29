using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseBenchmark.Domain.Entity
{
    public class JsonProducts
    {
        public virtual string Key { get; set; }
        public virtual IList<Product> Products { get; set; }
    }
}
