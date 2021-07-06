using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Dtos;
using Crime.API.Models;

namespace Crime.API.Services
{
    public interface ICrimeEventService
    {
        Task<IEnumerable<CrimeEventReadDto>> GetAllEvents();
        Task<CrimeEventReadDto> GetEventById(Guid id);
        Task<CrimeEventReadDto> PostEvent(CrimeEventPostDto dto);
        Task AddEnforcmentOfficerToEvent(Guid crimeEventId, Guid officerId);
        Task UpdateStatus(Guid crimeEventId, int status);
    }
}
