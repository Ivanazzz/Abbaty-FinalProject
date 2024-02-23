using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SchoolRegister.Models.CustomExceptions;
using SchoolRegister.Models.Dtos;
using SchoolRegister.Repositories.Users;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SchoolRegister.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class UserController : ControllerBase
    {
        private IUserRepository userRepository { get; set; }
        private IConfiguration _config;

        public UserController(IUserRepository userRepository, IConfiguration config)
        {
            this.userRepository = userRepository;
            _config = config;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody] UserRegistrationDto userRegistrationDto)
        {
            try
            {
                await userRepository.RegisterAsync(userRegistrationDto);

                return Ok();
            }
            catch (BadRequestException bre)
            {
                return BadRequest(bre.Message);
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromBody] UserLoginDto userLoginDto)
        {
            try
            {
                var user = await userRepository.LoginAsync(userLoginDto);

                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Issuer = "http://localhost:22333",
                    Audience = "http://localhost:22333",
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Email, user.Username)
                    }),
                    Expires = DateTime.Now.AddMinutes(120),
                    SigningCredentials = credentials
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                string userToken = tokenHandler.WriteToken(token);

                ResponseTokenDto accessToken = new ResponseTokenDto(userToken);

                return Ok(accessToken);
            }
            catch (NotFoundException nfe)
            {
                return BadRequest(nfe.Message);
            }
            catch (BadRequestException bre)
            {
                return BadRequest(bre.Message);
            }
        }

        [HttpGet("CurrentUser")]
        public async Task<IActionResult> GetAsync()
        {
            var username = HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;

            var user = await userRepository.GetUserAsync(username);

            return Ok(user);
        }
    }
}
