using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseBenchmark.Domain.Entity
{
    public class JsonProductsObject
    {
        public virtual string Key { get; set; }
        public virtual IList<JsonProducts>  Products { get; set; }
    }
}
