﻿using FluentNHibernate.Automapping;
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
    public class DBBenchmarkMySqlSession : IDbSession
    {
        private ISessionFactory _session;
        public string _connectionStringName { get; set; }

        public DBBenchmarkMySqlSession(string connectionStringName)
        {
            _connectionStringName = connectionStringName;
        }

        public ISessionFactory CreateSession()
        {
            
            if (_session != null)
            {
                return _session;
            }

            string connectionString = ConfigurationManager.ConnectionStrings[_connectionStringName].ToString();

            FluentConfiguration _config = Fluently.Configure()
               .Database(MySQLConfiguration.Standard.ConnectionString(connectionString))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ProductsObjectMap>());
            

            _session = _config.BuildSessionFactory();
            return _session;
        }

        public ISession SessionOpen()
        {
            return CreateSession().OpenSession();
        }

    }
}