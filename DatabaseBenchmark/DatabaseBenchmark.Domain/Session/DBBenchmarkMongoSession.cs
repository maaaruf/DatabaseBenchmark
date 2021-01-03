using MongoDB.Driver;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseBenchmark.Domain.Session
{
    public class DBBenchmarkMongoSession 
    {
        private MongoClient mongoClient { get; set; }
        private string _databaseName { get; set; }
        public IMongoDatabase session { get; set; }
        public DBBenchmarkMongoSession(string database)
        {
            mongoClient = new MongoClient();
            _databaseName = database;
            session = GetSession();
        }

        private IMongoDatabase GetSession()
        {
            MongoClient client = new MongoClient();
            var database = client.GetDatabase(_databaseName);
            return database;
        }
    }
}
