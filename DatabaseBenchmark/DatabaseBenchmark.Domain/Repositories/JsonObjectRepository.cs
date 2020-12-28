using DatabaseBenchmark.Domain.Entity;
using DatabaseBenchmark.Domain.Session;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseBenchmark.Domain.Repositories
{
    public class JsonObjectRepository : Repository<JsonObject, DBBenchmarkMySqlSession>
    {
        public JsonObjectRepository(DBBenchmarkMySqlSession MySqlSession) : base(MySqlSession)
        {
        }
    }
}
