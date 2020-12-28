using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Data;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using DatabaseBenchmark.Domain.Mappings;
using System.Configuration;

namespace DatabaseBenchmark.Domain.Session
{
    public class DBBenchmarkMySqlSession : IMySqlSession
    {
        private ISessionFactory _session;
       

        public ISessionFactory CreateSession()
        {
            
            if (_session != null)
            {
                return _session;
            }

            string connection = ConfigurationManager.ConnectionStrings["DBBenchmarkMySqlConnection"].ToString();

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