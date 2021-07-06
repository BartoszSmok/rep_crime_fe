using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Common.Dtos;
using Common.Exceptions;
using LawEnforcement.API.Data.Repositories;
using Newtonsoft.Json;

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

        public async Task<LawEnforcmentReadWithFullCasesDto> GetOfficerById(Guid id)
        {
            var officerInDb = await _repository.GetById(id);
            if (officerInDb == null)
                throw new NotFoundException("officer not found");

            var response = await _httpClient.GetAsync($"/api/crimes/officer/{id}");
            var content = await response.Content.ReadAsStringAsync();
            var crimeEvents = JsonConvert.DeserializeObject<IEnumerable<CrimeEventReadDto>>(content);

            var officerDto = _mapper.Map<LawEnforcmentReadWithFullCasesDto>(officerInDb);
            officerDto.AssignedCases = crimeEvents;

            return officerDto;
        }

        public async Task<LawEnforcmentReadDto> PostOfficer(LawEnforcmentPostDto dto)
        {
            var OfficerToAdd = _mapper.Map<Models.LawEnforcement>(dto);
            var crimeEventAdded = await _repository.Add(OfficerToAdd);

            return _mapper.Map<LawEnforcmentReadDto>(crimeEventAdded);
        }

        public async Task AddOfficerToEvent(Guid eventId, Guid officerId)
        {
            var officerInDb = await _repository.GetById(officerId);
            if (officerInDb == null)
                throw new NotFoundException("officer not found");

            await _httpClient.PostAsync($"/api/Crimes/{eventId}/officer/{officerId}",null);
        }
    }
}
