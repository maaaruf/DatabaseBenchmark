using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;


namespace DatabaseBenchmark.Domain.Session
{
    public class BenchmarkSession
    {
        private static ISessionFactory _session;


        //private static ISessionFactory CreateSession()
        //{
        //    if (_session != null)
        //    {
        //        return _session;
        //    }

        //    FluentConfiguration _config = Fluently.Configure()
        //        .Database(MySQLConfiguration.Standard.ConnectionString(m=>m.FromConnectionStringWithKey("test")))
        //}
    }
}
