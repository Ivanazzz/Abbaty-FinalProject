using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolRegister.Models.Dtos;
using SchoolRegister.Repositories.People;

namespace SchoolRegister.Controllers
{
    [ApiController]
    [Route("api/People")]
    public class PersonController : ControllerBase
    {
        private IPersonRepository personRepository { get; set; }

        public PersonController(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllPeopleAsync()
        {
            var people = await personRepository.GetAllPeopleAsync();

            return Ok(people);
        }

        [HttpGet("Filter")]
        [Authorize]
        public async Task<IActionResult> GetFilteredPeopleAsync([FromQuery] PersonFilterDto personDto)
        {
            var people = await personRepository.GetFilteredPeopleAsync(personDto);

            return Ok(people);
        }
    }
}
