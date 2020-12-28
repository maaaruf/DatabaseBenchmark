using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseBenchmark.Domain.Session
{
    public interface IMySqlSession
    {
        ISessionFactory CreateSession();
        ISession SessionOpen();
    }
}
