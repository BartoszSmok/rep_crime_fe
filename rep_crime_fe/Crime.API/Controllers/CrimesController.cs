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

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromRoute] Guid crimeEventId, [FromRoute] Guid officerId)
        {
            await _service.AddEnforcmentOfficerToEvent(crimeEventId, officerId);

            return Ok();
        }
    }
}
