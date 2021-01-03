using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseBenchmark.Domain.Service
{
    public interface IObjectToJsonConverterService
    {
        string Convert(object rawObject);
    }
}
