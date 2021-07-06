using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common.Dtos;
using Common.Exceptions;
using Crime.API.Data;
using Crime.API.Data.Repositories;
using Crime.API.Models;

namespace Crime.API.Services
{
    public class TypesOfCrimeServices: ITypesOfCrimeServices
    {
        private readonly ITypeRepository _repository;
        private readonly IMapper _mapper;

        public TypesOfCrimeServices(ITypeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<TypeOfCrimeReadDto>> GetAllTypes()
        {
            var typesInDb = await _repository.GetAll();
            var typesReadDto = _mapper.Map<IEnumerable<TypeOfCrimeReadDto>>(typesInDb);
            return typesReadDto;
        }


        public async Task<TypeOfCrimeReadDto> GetTypeById(int id)
        {
            var typeInDb = await _repository.GetById(id);
            if (typeInDb == null)
                throw new NotFoundException("Type Not Found");
            var typeReadDto = _mapper.Map<TypeOfCrimeReadDto>(typeInDb);
            return typeReadDto;
        }

        public async Task<TypeOfCrimeReadDto> PostType(TypeOfCrimePostDto dto)
        {
            var TypeOfCrimeToAdd = _mapper.Map<TypeOfCrime>(dto);
            var typeOfCrimeAdded = await _repository.Add(TypeOfCrimeToAdd);

            return _mapper.Map<TypeOfCrimeReadDto>(typeOfCrimeAdded);
        }
    }
}
