using DatabaseBenchmark.Domain.Entity;
using DatabaseBenchmark.Domain.Repositories.BaseRepository;
using DatabaseBenchmark.Domain.Session;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseBenchmark.Domain.Repositories
{
    public class ProductKeyRepository : Repository<ProductKey, LoadTestMySqlSession>, IProductKeyRepository
    {
        public ProductKeyRepository(LoadTestMySqlSession loadTestMySqlSession) : base(loadTestMySqlSession)
        {

        }
    }
}
