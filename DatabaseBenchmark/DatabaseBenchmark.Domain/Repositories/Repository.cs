using DatabaseBenchmark.Domain.Session;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DatabaseBenchmark.Domain.Repositories
{
    public class Repository<TEntity, TSession>
        where TEntity : class
        where TSession : IMySqlSession
    {

        public ISession _session { get; set; }
        public TSession _mySqlSession { get; set; }
        public Repository(TSession MySqlSession)
        {
            _mySqlSession = MySqlSession;
           // MySqlSession mySqlSession = new MySqlSession();
           //_session = mySqlSession.Session;
        }

        public virtual void Add(TEntity entity)
        {
            using (ISession session = _mySqlSession.SessionOpen())
            {
                session.Save(entity);
            }    
        }

        public virtual void Edit(TEntity entityToUpdate)
        {
            _session.Update(entityToUpdate);
        }

        public virtual TEntity GetSingle(Expression<Func<TEntity, bool>> filter)
        {

            using (ISession session = _mySqlSession.SessionOpen())
            {
                return session.QueryOver<TEntity>().Where(filter).SingleOrDefault();
            }
        }

        public virtual IList<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            return _session.QueryOver<TEntity>().Where(filter).List();
        }

        public virtual IList<TEntity> GetAll()
        {
            return _session.Query<TEntity>().ToList();
        }

        public virtual TEntity GetById(int id)
        {
            return _session.Get<TEntity>(id);
        }

        public virtual void Remove(int id)
        {
            _session.Delete(_session.Load<TEntity>(id));
        }

    }
}