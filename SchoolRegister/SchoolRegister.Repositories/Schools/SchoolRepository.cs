using Microsoft.EntityFrameworkCore;
using SchoolRegister.Models;
using SchoolRegister.Models.Dtos;

namespace SchoolRegister.Repositories.Schools
{
    public class SchoolRepository : ISchoolRepository
    {
        private readonly SchoolRegisterDbContext context;

        public SchoolRepository(SchoolRegisterDbContext context)
        {
            this.context = context;
        }

        public async Task<List<SchoolDto>> GetAllSchoolsAsync()
        {
            var schools = await context.Schools
                .Include(s => s.Settlement)
                .Where(u => u.IsActive == true)
                .ToListAsync();

            var schoolDtos = new List<SchoolDto>();

            foreach (var school in schools)
            {
                schoolDtos.Add(new SchoolDto()
                {
                    Id = school.Id,
                    Name = school.Name,
                    Type = school.Type,
                    Settlement = school.Settlement.Name
                });
            }

            return schoolDtos;
        }

        public async Task<List<SchoolDto>> GetFilteredSchoolsAsync(SchoolFilterDto filter)
        {
            var schools = await filter
                .WhereBuilder(context.Schools.Include(s => s.Settlement).AsQueryable())
                .ToListAsync();

            var schoolDtos = new List<SchoolDto>();

            foreach (var school in schools)
            {
                schoolDtos.Add(new SchoolDto()
                {
                    Id = school.Id,
                    Name = school.Name,
                    Type = school.Type,
                    Settlement = school.Settlement.Name
                });
            }

            return schoolDtos;
        }
    }
}
