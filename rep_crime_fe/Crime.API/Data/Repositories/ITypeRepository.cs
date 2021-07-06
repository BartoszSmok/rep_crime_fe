using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crime.API.Models;

namespace Crime.API.Data.Repositories
{
    public interface ITypeRepository
    {
        Task<IEnumerable<TypeOfCrime>> GetAll();
        Task<TypeOfCrime> GetById(Guid id);
        Task<TypeOfCrime> Add(TypeOfCrime typeOfCrime);
    }
}
