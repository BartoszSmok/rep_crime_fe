using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common.Dtos;
using Crime.API.Models;

namespace Crime.API.Profiles
{
    public class TypesOfCrimeProfiles:Profile
    {
        public TypesOfCrimeProfiles()
        {
            CreateMap<TypeOfCrime, TypeOfCrimeReadDto>();
            CreateMap<TypeOfCrimeReadDto, TypeOfCrime>();
            CreateMap<TypeOfCrime, TypeOfCrimePostDto>();
            CreateMap<TypeOfCrimePostDto, TypeOfCrime>();
        }
    }
}
