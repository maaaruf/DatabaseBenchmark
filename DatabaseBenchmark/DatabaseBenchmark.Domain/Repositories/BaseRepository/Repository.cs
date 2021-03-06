﻿using DatabaseBenchmark.Domain.Session;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DatabaseBenchmark.Domain.Repositories.BaseRepository
{
    public class Repository<TEntity, TSession> : IRepository<TEntity>
        where TEntity : class
        where TSession : IDbSession
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

        public virtual void Add(IList<TEntity> entities)
        {
            using (ISession session = _mySqlSession.SessionOpen())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    foreach (var entity in entities)
                    {
                        try
                        {
                            session.Save(entity);
                        }
                        catch(Exception e)
                        {
                            throw new Exception("Faild to save data for exception: "+e);
                        }
                    }

                    try
                    {
                        if(transaction.IsActive && transaction != null)
                        {
                            transaction.Commit();
                        }
                    }
                    catch(Exception e)
                    {
                        transaction.Rollback();
                        throw new Exception("Transection was faild for exception: " + e);
                    }
                }
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
                return session.Query<TEntity>().Where(filter).SingleOrDefault();
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