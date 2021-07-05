using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crime.API.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace Crime.API.Data
{
    public class CrimeContext: ICrimeContext
    {
        public CrimeContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
            CrimeEvents = database.GetCollection<CrimeEvent>(configuration.GetValue<string>("DatabaseSettings:CollectionName1"));
            TypeOfCrimes = database.GetCollection<TypeOfCrime>(configuration.GetValue<string>("DatabaseSettings:CollectionName2"));
        }

        public IMongoCollection<CrimeEvent> CrimeEvents { get; }
        public IMongoCollection<TypeOfCrime> TypeOfCrimes { get; }
    }
}
