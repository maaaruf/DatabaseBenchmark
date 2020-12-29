using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseBenchmark.Domain.Entity
{
    public class Product
    {
        public virtual long Id { get; set; }
        public virtual string Tittle { get; set; }
        public virtual string Brand { get; set; }
        public virtual double Price { get; set; }


    }
}
