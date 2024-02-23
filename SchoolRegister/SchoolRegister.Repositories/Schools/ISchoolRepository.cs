using SchoolRegister.Models.Dtos;

namespace SchoolRegister.Repositories.Schools
{
    public interface ISchoolRepository
    {
        Task<List<SchoolDto>> GetAllSchoolsAsync();

        Task<List<SchoolDto>> GetFilteredSchoolsAsync(SchoolFilterDto filter);
    }
}
