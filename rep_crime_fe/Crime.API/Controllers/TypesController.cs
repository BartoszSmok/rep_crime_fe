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
    public class TypesController : ControllerBase
    {
        private readonly ITypesOfCrimeServices _service;

        public TypesController(ITypesOfCrimeServices service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeOfCrimeReadDto>>> GetAll()
        {
            var result = await _service.GetAllTypes();

            return Ok(result);
        }

        [HttpGet("{id}", Name = ("GetById"))]
        public async Task<ActionResult<TypeOfCrimeReadDto>> GetById([FromRoute] int id)
        {
            var result = await _service.GetTypeById(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] TypeOfCrimePostDto dto)
        {
            var typeOfCrimeAddedToDb = await _service.PostType(dto);
            return CreatedAtRoute(nameof(GetById), new { id = typeOfCrimeAddedToDb.Id }, typeOfCrimeAddedToDb);
        }
    }
}
