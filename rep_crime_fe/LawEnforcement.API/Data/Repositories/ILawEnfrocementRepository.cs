using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LawEnforcement.API.Data.Repositories
{
    interface ILawEnfrocementRepository
    {
        Task<IEnumerable<Models.LawEnforcement>> GetAll();
        Task<Models.LawEnforcement> GetById(Guid id);
        Task<Models.LawEnforcement> Add(Models.LawEnforcement officer);
        Task Update(Models.LawEnforcement officer);
        Task Save();
    }
}
