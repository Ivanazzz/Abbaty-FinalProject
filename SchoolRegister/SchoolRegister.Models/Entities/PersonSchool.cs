using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SchoolRegister.Models.Common;
using SchoolRegister.Models.Enums;

namespace SchoolRegister.Models.Entities
{
    public class PersonSchool : IEntity, IAuditable
    {
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }

        public int CreatorUserId { get; set; }

        public Position Position { get; set; }

        public int PersonId { get; set; }

        public Person Person { get; set; }

        public int SchoolId { get; set; }

        public School School { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }

    public class PersonSchoolConfiguration : IEntityTypeConfiguration<PersonSchool>
    {
        public void Configure(EntityTypeBuilder<PersonSchool> builder)
        {
            builder.Property(b => b.Position)
                .IsRequired();

            builder.Property(b => b.PersonId)
                .IsRequired();

            builder.Property(b => b.SchoolId)
                .IsRequired();

            builder.Property(b => b.StartDate)
                .IsRequired();
        }
    }
}