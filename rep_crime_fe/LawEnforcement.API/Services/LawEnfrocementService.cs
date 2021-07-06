using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Common.Dtos;
using LawEnforcement.API.Data.Repositories;

namespace LawEnforcement.API.Profiles
{
    public class LawEnfrocementService: ILawEnfrocementService
    {
        private readonly ILawEnfrocementRepository _repository;
        private readonly IMapper _mapper;
        private HttpClient _httpClient;

        public LawEnfrocementService(ILawEnfrocementRepository repository, IMapper mapper, IHttpClientFactory httpClient)
        {
            _repository = repository;
            _mapper = mapper;
            _httpClient = httpClient.CreateClient("CrimeAPI");
        }
        public async Task<IEnumerable<LawEnforcmentReadDto>> GetAllOfficers()
        {
            var OfficersInDb = await _repository.GetAll();
            var officersDto = _mapper.Map<IEnumerable<LawEnforcmentReadDto>>(OfficersInDb);
            return officersDto;
        }

        public Task<LawEnforcmentReadDto> GetOfficerById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<LawEnforcmentReadDto> PostOfficer(LawEnforcmentPostDto dto)
        {
            var OfficerToAdd = _mapper.Map<Models.LawEnforcement>(dto);
            var crimeEventAdded = await _repository.Add(OfficerToAdd);

            return _mapper.Map<LawEnforcmentReadDto>(crimeEventAdded);
        }

        public async Task AddOfficerToEvent(Guid eventId, Guid officerId)
        {
            await _httpClient.PostAsync($"/api/Crimes/{eventId}/officer/{officerId}",null);
        }
    }
}
