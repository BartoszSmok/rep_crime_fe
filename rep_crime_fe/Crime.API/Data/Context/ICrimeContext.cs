using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crime.API.Models;
using MongoDB.Driver;

namespace Crime.API.Data
{
    public interface ICrimeContext
    {
        IMongoCollection<CrimeEvent> CrimeEvents { get; }
        IMongoCollection<TypeOfCrime> TypeOfCrimes { get; }
    }
}
