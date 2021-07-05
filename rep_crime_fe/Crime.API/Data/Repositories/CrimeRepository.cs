using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crime.API.Models;
using MongoDB.Driver;


namespace Crime.API.Data.Repositories
{
    public class CrimeRepository: ICrimeRepository
    {
        private readonly ICrimeContext _context;

        public CrimeRepository(ICrimeContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CrimeEvent>> GetAll()
        {
            return await _context.CrimeEvents.Find(x => true).ToListAsync();
        }

        public async Task<CrimeEvent> GetById(Guid id)
        {
            return await _context.CrimeEvents.Find(x => x.Id == id).FirstOrDefaultAsync();

        }

        public async Task<CrimeEvent> Add(CrimeEvent crimeEvent)
        {
            await _context.CrimeEvents.InsertOneAsync(crimeEvent);
            return crimeEvent;
        }

        public async Task Update(CrimeEvent crimeEvent)
        {
            await _context.CrimeEvents.ReplaceOneAsync(x => x.Id == crimeEvent.Id, crimeEvent);
        }

        public async Task Delete(CrimeEvent crimeEvent)
        {
            await _context.CrimeEvents.DeleteOneAsync(x => x.Id == crimeEvent.Id);
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }
    }
}
