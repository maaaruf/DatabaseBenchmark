using DatabaseBenchmark.Domain.Entity;
using DatabaseBenchmark.Domain.Repositories.BaseRepository;
using DatabaseBenchmark.Domain.Session;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseBenchmark.Domain.Repositories
{
    public class ProductsObjectMongoRepository : RepositoryMongo<ProductsObject, DBBenchmarkMongoSession>, IProductsObjectRepository
    {
        public ProductsObjectMongoRepository(DBBenchmarkMongoSession session, string tableName) : base(session, tableName)
        {
        }
    }
}
