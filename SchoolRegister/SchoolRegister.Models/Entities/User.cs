using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SchoolRegister.Models.Common;

namespace SchoolRegister.Models.Entities
{
    public class User : IEntity, IAuditable
    {
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }

        public int CreatorUserId { get; set; }

        public string Username { get; set; }

        public string Phone { get; set; }

        public string PasswordHash { get; set; }

        public string PasswordSalt { get; set; }

        public int SchoolId { get; set; }

        public School School { get; set; }

        public bool IsActive { get; set; }
    }

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(b => b.Username)
                .IsRequired();

            builder.HasIndex(b => b.Username)
                .IsUnique();

            builder.Property(b => b.Phone)
                .IsRequired();

            builder.Property(b => b.PasswordHash)
                .IsRequired();

            builder.Property(b => b.PasswordSalt)
                .IsRequired();

            builder.Property(b => b.SchoolId)
                .IsRequired();

            builder.Property(b => b.IsActive)
                .IsRequired()
                .HasDefaultValue(true);
        }
    }
}