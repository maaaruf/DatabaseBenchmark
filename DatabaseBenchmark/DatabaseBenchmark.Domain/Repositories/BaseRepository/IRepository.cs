using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DatabaseBenchmark.Domain.Repositories.BaseRepository
{
    public interface IRepository<TEntity>
    {
        void Add(TEntity entity);
        void Add(IList<TEntity> entities);
        void Edit(TEntity entityToUpdate);
        TEntity GetSingle(Expression<Func<TEntity, bool>> filter);
        //IList<TEntity> Get(Expression<Func<TEntity, bool>> filter);
        //IList<TEntity> GetAll();
    }
}
