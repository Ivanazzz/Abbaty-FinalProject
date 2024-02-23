using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolRegister.Models.Dtos;
using SchoolRegister.Repositories.Schools;

namespace SchoolRegister.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class SchoolController : ControllerBase
    {
        private ISchoolRepository schoolRepository { get; set; }

        public SchoolController(ISchoolRepository schoolRepository)
        {
            this.schoolRepository = schoolRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllSchoolsAsync()
        {
            var schools = await schoolRepository.GetAllSchoolsAsync();

            return Ok(schools);
        }

        [HttpGet("Filter")]
        [Authorize]
        public async Task<IActionResult> GetFilteredSchoolsAsync([FromQuery] SchoolFilterDto schoolDto)
        {
            var schools = await schoolRepository.GetFilteredSchoolsAsync(schoolDto);

            return Ok(schools);
        }
    }
}
