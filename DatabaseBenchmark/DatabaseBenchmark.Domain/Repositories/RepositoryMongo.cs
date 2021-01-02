using DatabaseBenchmark.Domain.Session;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DatabaseBenchmark.Domain.Repositories
{
    public class RepositoryMongo<TEntity, TSession>
        where TSession : DBBenchmarkMongoSession
    {
        private IMongoDatabase _session;
        private string table;

        public RepositoryMongo(TSession session, string table)
        {
            _session = session.session;
            this.table = table;
        }

        public virtual void Add(TEntity entity)
        {
            var collection = _session.GetCollection<TEntity>(table);
            collection.InsertOneAsync(entity);
        }

        public virtual void Add(IList<TEntity> entities)
        {
            var collection = _session.GetCollection<TEntity>(table);
            collection.InsertManyAsync(entities.AsEnumerable());
        }

        public virtual void Edit(TEntity entityToUpdate)
        {
            
        }

        public virtual TEntity GetSingle(Expression<Func<TEntity, bool>> filter)
        {
            var collection = _session.GetCollection<TEntity>(table);
            var data = collection.Find(filter).FirstOrDefault();
            return data;
        }

        //public virtual IList<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        //{

        //}

        //public virtual IList<TEntity> GetAll()
        //{

        //}

        //public virtual TEntity GetById(int id)
        //{
        //    var collection = _session.GetCollection<TEntity>(table);

        //}

        public virtual void Remove(int id)
        {
            
        }

    }
}
