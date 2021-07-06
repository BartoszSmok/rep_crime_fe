using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Dtos;

namespace LawEnforcement.API.Profiles
{
    public interface ILawEnfrocementService
    {
        Task<IEnumerable<LawEnforcmentReadDto>> GetAllOfficers();
        Task<LawEnforcmentReadWithFullCasesDto> GetOfficerById(Guid id);
        Task<LawEnforcmentReadDto> PostOfficer(LawEnforcmentPostDto dto);
        Task AddOfficerToEvent(Guid eventId, Guid officerId);
    }
}
