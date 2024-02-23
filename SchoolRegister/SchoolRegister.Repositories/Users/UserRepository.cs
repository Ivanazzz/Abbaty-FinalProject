using Microsoft.EntityFrameworkCore;
using SchoolRegister.Models;
using SchoolRegister.Models.CustomExceptionMessages;
using SchoolRegister.Models.CustomExceptions;
using SchoolRegister.Models.Dtos;
using SchoolRegister.Models.Entities;
using System.Security.Cryptography;
using System.Text;

namespace SchoolRegister.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly SchoolRegisterDbContext context;
        const int keySize = 64;
        const int iterations = 350000;
        HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

        public UserRepository(SchoolRegisterDbContext context)
        {
            this.context = context;
        }

        public async Task RegisterAsync(UserRegistrationDto userRegistrationDto)
        {
            bool userExists = await context.Users
                .FirstOrDefaultAsync(u => u.Username == userRegistrationDto.Username && u.IsActive == true) != null
                    ? true
                    : false;

            if (userExists)
            {
                throw new BadRequestException(ExceptionMessages.AlreadyExistingUser);
            }

            var school = await context.Schools
                .FirstOrDefaultAsync(s => s.Name == userRegistrationDto.SchoolName);

            if (school == null)
            {
                throw new BadRequestException(ExceptionMessages.NonExistentSchool);
            }

            var hashedPassword = HashPasword(userRegistrationDto.Password, out var salt);
            var userSalt = Convert.ToHexString(salt);

            var user = new User()
            {
                Username = userRegistrationDto.Username,
                Phone = userRegistrationDto.Phone,
                PasswordHash = hashedPassword,
                PasswordSalt = userSalt,
                SchoolId = school.Id,
                IsActive = true
            };

            context.Users.Add(user);
            await context.SaveChangesAsync();
        }

        public async Task<User> LoginAsync(UserLoginDto userLoginDto)
        {
            var user = await context.Users
                .FirstOrDefaultAsync(u => u.Username == userLoginDto.Username
                    && u.IsActive == true);

            if (user == null)
            {
                throw new NotFoundException(ExceptionMessages.NonExistentUser);
            }

            bool isPasswordValid = VerifyPassword(userLoginDto.Password, user.PasswordHash, Convert.FromHexString(user.PasswordSalt));

            if (!isPasswordValid)
            {
                throw new BadRequestException(ExceptionMessages.InvalidUserPassword);
            }

            return user;
        }

        public async Task<UserDto> GetUserAsync(string username)
        {
            var user = await context.Users
                .FirstOrDefaultAsync(u => u.Username == username
                    && u.IsActive == true);

            if (user == null)
            {
                return null;
            }

            var userDto = new UserDto()
            {
                Id = user.Id,
                Username = user.Username,
                Phone = user.Phone
            };

            return userDto;
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            var users = await context.Users
                .Include(u => u.School)
                .Where(u => u.IsActive == true)
                .ToListAsync();

            var userDtos = new List<UserDto>();

            foreach (var user in users)
            {
                userDtos.Add(new UserDto()
                {
                    Id = user.Id,
                    Username = user.Username,
                    Phone = user.Phone,
                    SchoolName = user.School.Name
                });
            }

            return userDtos;
        }

        public async Task<List<UserDto>> GetFilteredUsersAsync(UserFilterDto filter)
        {
            var users = await filter
                .WhereBuilder(context.Users.Include(u => u.School).AsQueryable())
                .ToListAsync();

            var userDtos = new List<UserDto>();

            foreach (var user in users)
            {
                userDtos.Add(new UserDto()
                {
                    Id = user.Id,
                    Username = user.Username,
                    Phone = user.Phone,
                    SchoolName = user.School.Name
                });
            }

            return userDtos;
        }

        private string HashPasword(string password, out byte[] salt)
        {
            salt = RandomNumberGenerator.GetBytes(keySize);

            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
            salt,
                iterations,
                hashAlgorithm,
                keySize);

            return Convert.ToHexString(hash);
        }

        private bool VerifyPassword(string password, string hash, byte[] salt)
        {
            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, hashAlgorithm, keySize);

            return CryptographicOperations.FixedTimeEquals(hashToCompare, Convert.FromHexString(hash));
        }
    }
}
