using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LawEnforcement.API.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace LawEnforcement.API.Data.Repositories
{
    public class LawEnfrocementRepository: ILawEnfrocementRepository
    {
        private readonly LawEnforcementContext _context;

        public LawEnfrocementRepository(LawEnforcementContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Models.LawEnforcement>> GetAll()
        {
            return await _context.LawOfficers.ToListAsync();
        }

        public async Task<Models.LawEnforcement> GetById(Guid id)
        {
            return await _context.LawOfficers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Models.LawEnforcement> Add(Models.LawEnforcement officer)
        {
            await _context.AddAsync(officer);
            await Save();
            return officer;
        }

        public async Task Update(Models.LawEnforcement officer)
        { 
            _context.Update(officer);
            await Save();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
