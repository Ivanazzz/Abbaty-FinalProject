using SchoolRegister.Models.Enums;

namespace SchoolRegister.Models.Dtos
{
    public class SchoolDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public SchoolType Type { get; set; }

        public string Settlement { get; set; }
    }
}
