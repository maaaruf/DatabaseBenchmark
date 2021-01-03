using DatabaseBenchmark.Domain.Entity;
using DatabaseBenchmark.Domain.Repositories.BaseRepository;
using DatabaseBenchmark.Domain.Session;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace DatabaseBenchmark.Domain.Repositories
{
    public class ProductsObjectRepository : Repository<ProductsObject, DBBenchmarkMySqlSession>, IProductsObjectRepository
    {
        public ProductsObjectRepository(DBBenchmarkMySqlSession session) : base(session)
        {
            
        }

        //public override void Add(IList<ProductsObject> entities)
        //{
        //    //var data = ConvertToJsonObject(entities);
        //    using (ISession session = _mySqlSession.SessionOpen())
        //    {
        //        using (ITransaction transaction = session.BeginTransaction())
        //        {
        //            foreach (var entity in data)
        //            {
        //                try
        //                {
        //                    session.Save(entity);
        //                }
        //                catch (Exception e)
        //                {
        //                    throw new Exception("Faild to save data for exception: " + e);
        //                }
        //            }

        //            try
        //            {
        //                if (transaction.IsActive && transaction != null)
        //                {
        //                    transaction.Commit();
        //                }
        //            }
        //            catch(Exception e)
        //            {
        //                transaction.Rollback();
        //                throw new Exception("Transection was faild for exception: "+e);
        //            }
        //        }
        //    }
        //}


        //public IList<JsonObject> ConvertToJsonObject(IList<ProductsObject> entities)
        //{
        //    IList<JsonObject> objects = new List<JsonObject>();
        //    objects = entities.Select(p => new JsonObject
        //    {
        //        ProductKey = p.ProductKey,
        //        ProductValue = JsonSerializer.Serialize(p.Products)
        //    }).ToList();

        //    return objects;
        //}
    }
}
