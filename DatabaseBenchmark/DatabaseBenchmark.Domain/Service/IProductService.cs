using DatabaseBenchmark.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseBenchmark.Domain.Service
{
    public interface IProductService
    {
        IList<ProductsObject> GenerateJsonProducts(int dataCount);
        TimeSpan InsertProducts(IList<ProductsObject> products);
        ProductsObject GetSingleKeysProduct(string key);
        void InsertKey(string key);

    }
}
