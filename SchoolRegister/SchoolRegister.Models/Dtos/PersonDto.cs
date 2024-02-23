using SchoolRegister.Models.Enums;

namespace SchoolRegister.Models.Dtos
{
    public class PersonDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Uic { get; set; }

        public string BirthDate { get; set; }

        public Gender Gender { get; set; }

        public string BirthPlace { get; set; }
    }
}
