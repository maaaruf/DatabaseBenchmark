using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseBenchmark.Domain.Entity
{
    public class JsonObject
    {
        [BsonId]
        public virtual string ProductKey { get; set; }
        public virtual string ProductValue { get; set; }
    }
}
