using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crime.API.Models;
using MongoDB.Driver;

namespace Crime.API.Data.Repositories
{
    public class TypeRepository: ITypeRepository
    {
        private readonly ICrimeContext _context;

        public TypeRepository(ICrimeContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TypeOfCrime>> GetAll()
        {
            return await _context.TypeOfCrimes.Find(x => true).ToListAsync();
        }

        public async Task<TypeOfCrime> GetById(Guid id)
        {
            return await _context.TypeOfCrimes.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<TypeOfCrime> Add(TypeOfCrime typeOfCrime)
        {
            await _context.TypeOfCrimes.InsertOneAsync(typeOfCrime);
            return typeOfCrime;
        }
    }
}
