using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseBenchmark.Domain.Session
{
    public interface IDbSession
    {
        ISessionFactory CreateSession();
        ISession SessionOpen();
    }
}
