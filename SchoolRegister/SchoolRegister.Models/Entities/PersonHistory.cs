using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SchoolRegister.Models.Common;
using SchoolRegister.Models.Enums;

namespace SchoolRegister.Models.Entities
{
    public class PersonHistory : IEntity, IAuditable
    {
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }

        public int CreatorUserId { get; set; }

        public int PersonId { get; set; }

        public Person Person { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public DateTime ActionDate { get; set; }

        public DataModified DataModified { get; set; }

        public ModificationType Type { get; set; }
    }

    public class PersonHistoryConfiguration : IEntityTypeConfiguration<PersonHistory>
    {
        public void Configure(EntityTypeBuilder<PersonHistory> builder)
        {
            builder.Property(b => b.PersonId)
                .IsRequired();

            builder.Property(b => b.UserId)
                .IsRequired();

            builder.Property(b => b.ActionDate)
                .IsRequired();

            builder.Property(b => b.DataModified)
                .IsRequired();

            builder.Property(b => b.Type)
                .IsRequired();
        }
    }
}
