using DatabaseBenchmark.Domain.Entity;
using DatabaseBenchmark.Domain.Session;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseBenchmark.Domain.Repositories
{
    public class ProductsObjectMongoRepository : RepositoryMongo<ProductsObject, DBBenchmarkMongoSession>, IProductsObjectRepository
    {
        public ProductsObjectMongoRepository() : base(new DBBenchmarkMongoSession("dbb"), "productscopy")
        {
        }
    }
}
