using DatabaseBenchmark.Domain.Entity;
using DatabaseBenchmark.Domain.Session;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseBenchmark.Domain.Repositories
{
    public class ProductsObjectRepository : Repository<JsonObject, DBBenchmarkMySqlSession>
    {
        public ProductsObjectRepository() : base(new DBBenchmarkMySqlSession())
        {
        }
    }
}
