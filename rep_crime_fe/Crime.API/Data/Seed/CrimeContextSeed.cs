using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crime.API.Models;
using MongoDB.Driver;

namespace Crime.API.Data.Seed
{
    public static class CrimeContextSeed
    {
        public static void SeedData(IMongoCollection<TypeOfCrime> typeOfCrime)
        {
            bool existPatient = typeOfCrime.Find(p => true).Any();
            if (!existPatient)
            {
                typeOfCrime.InsertMany(Types());
            }
        }
        private static IEnumerable<TypeOfCrime> Types()
        {
            var list = new List<TypeOfCrime>()
            {
                new TypeOfCrime()
                {
                    Id = new Guid("451539c5-a70c-43ca-b04a-4496b8a9fb6d"),
                    Name = "Burglary"
                },
                new TypeOfCrime()
                {
                    Id = new Guid("13abf617-fbf0-4059-98a1-8c2247a7a9dd"),
                    Name = "Vandalism"
                },
                new TypeOfCrime()
                {
                    Id = new Guid("65cfd4ff-0dbb-4de6-8133-5dd3aa9a5879"),
                    Name = "Murder"
                },
                new TypeOfCrime()
                {
                    Id = new Guid("3cfeaba5-6362-481b-a2da-693328cd8141"),
                    Name = "Robbery"
                }
            };
            return list;
        }

    }
}
