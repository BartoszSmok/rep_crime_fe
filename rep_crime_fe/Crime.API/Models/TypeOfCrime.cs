using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace Crime.API.Models
{
    public class TypeOfCrime
    {
        [BsonId]
        public Guid Id { get; set; }
        public string Name { get; set; }

    }
}
