using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common.Dtos;

namespace LawEnforcement.API.Services
{
    public class LawEnfrocementProfiles: Profile
    {
        public LawEnfrocementProfiles()
        {
            CreateMap<Models.LawEnforcement, LawEnforcmentReadDto>();
            CreateMap<LawEnforcmentReadDto, Models.LawEnforcement>();
            CreateMap<Models.LawEnforcement, LawEnforcmentPostDto>();
            CreateMap<LawEnforcmentPostDto, Models.LawEnforcement>();
            CreateMap<Models.LawEnforcement, LawEnforcmentReadWithFullCasesDto>();
            CreateMap<LawEnforcmentReadWithFullCasesDto, Models.LawEnforcement>();
        }
    }
}
