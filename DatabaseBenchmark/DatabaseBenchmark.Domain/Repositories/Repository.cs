using Blog.Framework.Sessions;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DatabaseBenchmark.Domain.Repositories
{
    public class Repository<TEntity>
        where TEntity : class
    {

        public ISession _session { get; set; }
        public Repository()
        {
           // MySqlSession mySqlSession = new MySqlSession();
            //_session = mySqlSession.Session;
        }

        public virtual void Add(TEntity entity)
        {
            using (ISession session = MySqlSession.SessionOpen())
            {
                session.Save(entity);
            }

                
        }

        public virtual void Edit(TEntity entityToUpdate)
        {
            _session.Update(entityToUpdate);
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