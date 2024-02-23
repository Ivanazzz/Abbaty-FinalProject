using SchoolRegister.Models.Common;
using SchoolRegister.Models.Entities;
using SchoolRegister.Models.Enums;

namespace SchoolRegister.Models.Dtos
{
    public class PersonFilterDto : IFilter<Person>
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Uic { get; set; }

        public string BirthDate { get; set; }

        public Gender? Gender { get; set; }

        public string BirthPlace { get; set; }

        public IQueryable<Person> WhereBuilder(IQueryable<Person> query)
        {
            if (!string.IsNullOrEmpty(FirstName))
            {
                query = query.Where(p => p.FirstName == FirstName);
            }

            if (!string.IsNullOrEmpty(MiddleName))
            {
                query = query.Where(p => p.MiddleName == MiddleName);
            }

            if (!string.IsNullOrEmpty(LastName))
            {
                query = query.Where(p => p.LastName == LastName);
            }

            if (!string.IsNullOrEmpty(Uic))
            {
                query = query.Where(p => p.Uic == Uic);
            }

            if (!string.IsNullOrEmpty(BirthDate))
            {
                query = query.Where(p => p.BirthDate == DateTime.SpecifyKind(DateTime.Parse(BirthDate), DateTimeKind.Utc));
            }

            if (Gender.HasValue)
            {
                query = query.Where(p => p.Gender == Gender);
            }

            if (!string.IsNullOrEmpty(BirthPlace))
            {
                query = query.Where(p => p.BirthPlace.Name == BirthPlace);
            }

            return query;
        }
    }
}
