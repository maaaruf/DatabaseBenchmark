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

        public TSession _mySqlSession { get; set; }
        public Repository(TSession MySqlSession)
        {
            _mySqlSession = MySqlSession;
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
            using (ISession session = _mySqlSession.SessionOpen())
            {
                session.Update(entityToUpdate);
            }
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
            using (ISession session = _mySqlSession.SessionOpen())
            {
                return session.QueryOver<TEntity>().Where(filter).List();
            }
        }

        public virtual IList<TEntity> GetAll()
        {
            using (ISession session = _mySqlSession.SessionOpen())
            {
                return session.Query<TEntity>().ToList();
            }
        }

        public virtual TEntity GetById(int id)
        {
            using (ISession session = _mySqlSession.SessionOpen())
            {
                return session.Get<TEntity>(id);
            }
        }

        public virtual void Remove(int id)
        {
            using (ISession session = _mySqlSession.SessionOpen())
            {
                session.Delete(session.Load<TEntity>(id));
            }
        }

    }
}