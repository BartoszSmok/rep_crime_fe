using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Dtos;
using LawEnforcement.API.Profiles;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace LawEnforcement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficersController : ControllerBase
    {
        private readonly ILawEnfrocementService _service;

        public OfficersController(ILawEnfrocementService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LawEnforcmentReadDto>>> GetAll()
        {
            var result = await _service.GetAllOfficers();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] LawEnforcmentPostDto dto)
        {
            var officerAddedToDb = await _service.PostOfficer(dto);
            return Ok();
            //return CreatedAtRoute(nameof(GetById), new { id = officerAddedToDb.Id }, officerAddedToDb);
        }

        [HttpPost("{officerId}/event/{crimeEventId}")]
        public async Task<ActionResult> AddOfficerToEvent([FromRoute] Guid officerId, [FromRoute] Guid crimeEventId)
        {
            await _service.AddOfficerToEvent(crimeEventId, officerId);
            return Ok();
            //return CreatedAtRoute(nameof(GetById), new { id = officerAddedToDb.Id }, officerAddedToDb);
        }
    }
}
