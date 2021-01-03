using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseBenchmark.Domain.Entity
{
    public class ProductsObject
    {
        [BsonId]
        public virtual string ProductKey { get; set; }
        public virtual IList<Product> Products { get; set; }
        [BsonIgnore]
        public virtual string ProductValue { get; set; }
    }
}
