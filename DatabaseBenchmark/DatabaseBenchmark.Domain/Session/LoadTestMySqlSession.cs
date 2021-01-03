using DatabaseBenchmark.Domain.Mappings;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace DatabaseBenchmark.Domain.Session
{
    public class LoadTestMySqlSession : IDbSession
    {
        private ISessionFactory _session;


        public ISessionFactory CreateSession()
        {

            if (_session != null)
            {
                return _session;
            }

            string connection = ConfigurationManager.ConnectionStrings["LoadTestMySqlConnection"].ToString();

            FluentConfiguration _config = Fluently.Configure()
               .Database(MySQLConfiguration.Standard.ConnectionString(connection))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<JsonObjectMap>());

            _session = _config.BuildSessionFactory();
            return _session;
        }

        public ISession SessionOpen()
        {
            return CreateSession().OpenSession();
        }
    }
}
