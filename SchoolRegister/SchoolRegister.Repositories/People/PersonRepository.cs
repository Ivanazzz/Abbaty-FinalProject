using SchoolRegister.Models.Dtos;
using SchoolRegister.Models;
using Microsoft.EntityFrameworkCore;

namespace SchoolRegister.Repositories.People
{
    public class PersonRepository : IPersonRepository
    {
        private readonly SchoolRegisterDbContext context;

        public PersonRepository(SchoolRegisterDbContext context)
        {
            this.context = context;
        }

        public async Task<List<PersonDto>> GetAllPeopleAsync()
        {
            var people = await context.Persons
                .Include(p => p.BirthPlace)
                .ToListAsync();

            var personDtos = new List<PersonDto>();

            foreach (var person in people)
            {
                personDtos.Add(new PersonDto()
                {
                    Id = person.Id,
                    FirstName = person.FirstName,
                    MiddleName = person.MiddleName,
                    LastName = person.LastName,
                    Uic = person.Uic,
                    BirthDate = person.BirthDate.ToString("yyyy-MM-dd"),
                    Gender = person.Gender,
                    BirthPlace = person.BirthPlace.Name
                });
            }

            return personDtos;
        }

        public async Task<List<PersonDto>> GetFilteredPeopleAsync(PersonFilterDto filter)
        {
            var people = await filter
                .WhereBuilder(context.Persons.Include(p => p.BirthPlace).AsQueryable())
                .ToListAsync();

            var personDtos = new List<PersonDto>();

            foreach (var person in people)
            {
                personDtos.Add(new PersonDto()
                {
                    Id = person.Id,
                    FirstName = person.FirstName,
                    MiddleName = person.MiddleName,
                    LastName = person.LastName,
                    Uic = person.Uic,
                    BirthDate = person.BirthDate.ToString("yyyy-MM-dd"),
                    Gender = person.Gender,
                    BirthPlace = person.BirthPlace.Name
                });
            }

            return personDtos;
        }
    }
}
