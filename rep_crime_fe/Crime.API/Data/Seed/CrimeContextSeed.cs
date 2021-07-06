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
                    Id = 1,
                    Name = "Burglary"
                },
                new TypeOfCrime()
                {
                    Id = 2,
                    Name = "Vandalism"
                },
                new TypeOfCrime()
                {
                    Id = 3,
                    Name = "Murder"
                },
                new TypeOfCrime()
                {
                    Id = 4,
                    Name = "Robbery"
                }
            };
            return list;
        }

    }
}
