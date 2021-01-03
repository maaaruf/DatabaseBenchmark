using DatabaseBenchmark.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace DatabaseBenchmark.Domain.Service
{
    public class JsonToObjectConverterService<T> : IJsonToObjectConverterService<T>
    {
        //IList<T> Convert(string data)
        //{
        //    IList<T> ObjectData = (IList<T>)JsonSerializer.Deserialize<T>(data);
        //    return ObjectData;
        //}


        //TODO Findout why without IJsonToObjectConverterService<T>.Convert giving error
        IList<T> IJsonToObjectConverterService<T>.Convert(string data)
        {
            IList<T> ObjectData = (IList<T>)JsonSerializer.Deserialize<T>(data);
            return ObjectData;
        }
    }
}
