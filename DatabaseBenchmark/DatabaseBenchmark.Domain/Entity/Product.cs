using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseBenchmark.Domain.Entity
{
    public class Product
    {
        public long Id { get; set; }
        public string Tittle { get; set; }
        public string Brand { get; set; }
        public double Price { get; set; }


    }
}
