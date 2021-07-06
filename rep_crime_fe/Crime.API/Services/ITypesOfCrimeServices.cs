using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Dtos;

namespace Crime.API.Services
{
    public interface ITypesOfCrimeServices
    {
        Task<IEnumerable<TypeOfCrimeReadDto>> GetAllTypes();
        Task<TypeOfCrimeReadDto> GetTypeById(int id);
        Task<TypeOfCrimeReadDto> PostType(TypeOfCrimePostDto dto);
    }
}
