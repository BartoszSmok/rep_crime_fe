using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crime.API.Models;

namespace Crime.API.Data.Repositories
{
    public interface ICrimeRepository
    {
        Task<IEnumerable<CrimeEvent>> GetAll();
        Task<CrimeEvent> GetById(Guid id);
        Task<CrimeEvent> Add(CrimeEvent crimeEvent);
        Task Update(CrimeEvent crimeEvent);
        Task Delete(CrimeEvent crimeEvent);
        Task Save();
    }
}
