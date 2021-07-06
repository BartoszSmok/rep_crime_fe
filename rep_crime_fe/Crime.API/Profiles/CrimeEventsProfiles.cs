using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common.Dtos;
using Crime.API.Models;

namespace Crime.API.Profiles
{
    public class CrimeEventsProfiles: Profile
    {
        public CrimeEventsProfiles()
        {
            CreateMap<CrimeEvent, CrimeEventReadDto>();
            CreateMap<CrimeEventReadDto, CrimeEvent>();
            CreateMap<CrimeEventPostDto, CrimeEvent>();
            CreateMap<CrimeEvent, CrimeEventPostDto>();
            CreateMap<CrimeEventUpdateDto, CrimeEvent>();
            CreateMap<CrimeEvent, CrimeEventUpdateDto>();
        }
    }
}
