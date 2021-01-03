using DatabaseBenchmark.Domain.Entity;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseBenchmark.Domain.Mappings
{
    public class ProductsObjectMap : ClassMap<ProductsObject>
    {
        public ProductsObjectMap()
        {
            Id(x => x.ProductKey);
            Map(x => x.ProductValue);
            Table("products");
        }
    }
}
