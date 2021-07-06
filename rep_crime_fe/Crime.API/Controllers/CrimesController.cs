using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Dtos;
using Crime.API.Services;


namespace Crime.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrimesController : ControllerBase
    {
        private readonly ICrimeEventService _service;

        public CrimesController(ICrimeEventService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CrimeEventReadDto>>> GetAll()
        {
            var result = await _service.GetAllEvents();

            return Ok(result);
        }

        [HttpGet("{id}", Name = ("GetById"))]
        public async Task<ActionResult<CrimeEventReadDto>> GetById([FromRoute] Guid id)
        {
            var result = await _service.GetEventById(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CrimeEventPostDto dto)
        {
            var crimeEventAddedToDb = await _service.PostEvent(dto);
            return CreatedAtRoute(nameof(GetById), new { id = crimeEventAddedToDb.Id }, crimeEventAddedToDb);
        }

        [HttpPost("{crimeEventId}/officer/{officerId}")]
        public async Task<ActionResult> UpdateWithOfficer([FromRoute] Guid crimeEventId, [FromRoute] Guid officerId)
        {
            await _service.AddEnforcmentOfficerToEvent(crimeEventId, officerId);

            return Ok();
        }

        [HttpPost("{crimeEventId}/status/{status}")]
        public async Task<ActionResult> UpdateStatus([FromRoute] Guid crimeEventId, [FromRoute] int status)
        {
            await _service.UpdateStatus(crimeEventId, status);

            return Ok();
        }
    }
}
