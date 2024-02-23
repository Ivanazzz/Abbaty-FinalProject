using SchoolRegister.Models.Dtos;

namespace SchoolRegister.Repositories.People
{
    public interface IPersonRepository
    {
        Task<List<PersonDto>> GetAllPeopleAsync();

        Task<List<PersonDto>> GetFilteredPeopleAsync(PersonFilterDto filter);
    }
}
