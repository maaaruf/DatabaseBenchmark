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

namespace Blog.Framework.Sessions
{
    public class MySqlSession 
    {
        private static ISessionFactory _session;

        private static ISessionFactory CreateSession()
        {
            if (_session != null)
            {
                return _session;
            }

            FluentConfiguration _config = Fluently.Configure()
                .Database(MySQLConfiguration.Standard.ConnectionString("server=localhost;user id=root;password=123456;database=dbbenchmark"))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<JsonObjectMap>());
            

            _session = _config.BuildSessionFactory();
            return _session;
        }

        public static ISession SessionOpen()
        {
            return CreateSession().OpenSession();
        }
    }
}