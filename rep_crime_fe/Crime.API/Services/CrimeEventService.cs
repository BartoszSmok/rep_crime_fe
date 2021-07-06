using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common.Dtos;
using Common.Exceptions;
using Crime.API.Data.Repositories;
using Crime.API.Models;
using Status = Crime.API.Models.Status;

namespace Crime.API.Services
{
    public class CrimeEventService: ICrimeEventService
    {
        private readonly ICrimeRepository _repository;
        private readonly IMapper _mapper;

        public CrimeEventService(ICrimeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CrimeEventReadDto>> GetAllEvents()
        {
            var eventsInDb = await _repository.GetAll();
            var eventsDto = _mapper.Map<IEnumerable<CrimeEventReadDto>>(eventsInDb);
            return eventsDto;
        }

        public async Task<CrimeEventReadDto> GetEventById(Guid id)
        {
            var eventInDb = await _repository.GetById(id);
            if (eventInDb == null)
                throw new NotFoundException("Event Not Found");
            var eventDto = _mapper.Map<CrimeEventReadDto>(eventInDb);
            return eventDto;
        }

        public async Task<CrimeEventReadDto> PostEvent(CrimeEventPostDto dto)
        {
            if (dto.DateOfCrime == null)
                dto.DateOfCrime = DateTime.Now;
            var crimeEventToAdd = _mapper.Map<CrimeEvent>(dto);
            var crimeEventAdded = await _repository.Add(crimeEventToAdd);
            
            return _mapper.Map<CrimeEventReadDto>(crimeEventAdded);
        }

        public async Task AddEnforcmentOfficerToEvent(Guid crimeEventId, Guid officerId)
        {
            var eventInDb = await _repository.GetById(crimeEventId);
            if (eventInDb == null)
                throw new NotFoundException("Event Not Found");

            eventInDb.AssignedLawEnforcmentId = officerId;

            await _repository.Update(eventInDb);
        }

        public async Task UpdateStatus(Guid crimeEventId, int status)
        {
            var eventInDb = await _repository.GetById(crimeEventId);
            if (eventInDb == null)
                throw new NotFoundException("Event Not Found");
            var newStatus = (Status)status;
            eventInDb.Status = newStatus;
            await _repository.Update(eventInDb);
        }
    }
}
