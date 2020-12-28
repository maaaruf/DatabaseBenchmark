using DatabaseBenchmark.Domain.Entity;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseBenchmark.Domain.Mappings
{
    public class ProductKeyMap : ClassMap<ProductKey>
    {
        public ProductKeyMap()
        {
            Id(x => x.Id);
            Map(x => x.ProductsKey);
            Table("ProductKeys");
        }
    }
}
