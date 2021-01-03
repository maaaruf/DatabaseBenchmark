using DatabaseBenchmark.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseBenchmark.Domain.Service
{
    public interface IRandomDataGeneratorService
    {
        IList<Product> GenerateProducts(int productCount);
    }
}
