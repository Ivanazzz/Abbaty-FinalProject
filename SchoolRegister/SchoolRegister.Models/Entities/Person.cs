using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SchoolRegister.Models.Common;
using SchoolRegister.Models.Enums;

namespace SchoolRegister.Models.Entities
{
    public class Person : IEntity, IAuditable
    {
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }

        public int CreatorUserId { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Uic { get; set; }

        public DateTime BirthDate { get; set; }

        public Gender Gender { get; set; }

        public int BirthPlaceId { get; set; }

        public Settlement BirthPlace { get; set; }
    }

    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(b => b.FirstName)
                .IsRequired();

            builder.Property(b => b.LastName)
                .IsRequired();

            builder.Property(b => b.Uic)
                .IsRequired();

            builder.HasIndex(b => b.Uic)
                .IsUnique();

            builder.Property(b => b.BirthDate)
                .IsRequired();

            builder.Property(b => b.Gender)
                .IsRequired();

            builder.Property(b => b.BirthPlaceId)
                .IsRequired();
        }
    }
}
