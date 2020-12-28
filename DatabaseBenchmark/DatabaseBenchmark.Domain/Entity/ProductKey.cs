using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseBenchmark.Domain.Entity
{
    public class ProductKey
    {
        public virtual int Id { get; set; }
        public virtual string ProductsKey { get; set; }
    }
}
