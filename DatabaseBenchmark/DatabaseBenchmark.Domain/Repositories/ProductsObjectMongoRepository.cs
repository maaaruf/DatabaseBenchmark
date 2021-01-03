using DatabaseBenchmark.Domain.Entity;
using DatabaseBenchmark.Domain.Session;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseBenchmark.Domain.Repositories
{
    public class ProductsObjectMongoRepository : RepositoryMongo<ProductsObject, DBBenchmarkMongoSession>
    {
        public ProductsObjectMongoRepository(DBBenchmarkMongoSession session, string table= "products") : base(new DBBenchmarkMongoSession("dbb"), table)
        {
        }
    }
}
