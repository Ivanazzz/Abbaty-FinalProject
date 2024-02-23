using SchoolRegister.Models.Dtos;
using SchoolRegister.Models.Entities;

namespace SchoolRegister.Repositories.Users
{
    public interface IUserRepository
    {
        Task RegisterAsync(UserRegistrationDto userRegistrationDto);

        Task<User> LoginAsync(UserLoginDto userLoginDto);

        Task<UserDto> GetUserAsync(string username);
    }
}
