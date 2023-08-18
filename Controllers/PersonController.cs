using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_NET_7.Services.PersonService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonApiDotNet7.Models;

namespace CRUD_NET_7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Person>>> GetAllPeople()
        {
            return await _personService.GetAllPeople();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPersonById(int id)
        {
            var person = await _personService.GetPersonById(id);
            if (person is null)
            {
                return NotFound("No such person");
            }
            return Ok(person);
        }

        [HttpPost]
        public async Task<ActionResult<List<Person>>> AddPerson([FromBody]Person person)
        {
            var result = await _personService.AddPerson(person);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePersonById(int id, Person person)
        {
            await _personService.UpdatePersonById(id, person);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePersonById(int id)
        {
            await _personService.DeletePersonById(id);
            return NoContent();
        }
    }
}
