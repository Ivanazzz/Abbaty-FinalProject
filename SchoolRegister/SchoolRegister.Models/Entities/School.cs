using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SchoolRegister.Models.Common;
using SchoolRegister.Models.Enums;

namespace SchoolRegister.Models.Entities
{
    public class School : IEntity, IAuditable
    {
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }

        public int CreatorUserId { get; set; }

        public string Name { get; set; }

        public string NameAlt { get; set; }

        public SchoolType Type { get; set; }

        public int SettlementId { get; set; }

        public Settlement Settlement { get; set; }
        
        public bool IsActive { get; set; }
    }

    public class SchoolConfiguration : IEntityTypeConfiguration<School>
    {
        public void Configure(EntityTypeBuilder<School> builder)
        {
            builder.Property(b => b.Name)
                .IsRequired();

            builder.Property(b => b.NameAlt)
                .IsRequired();

            builder.Property(b => b.Type)
                .IsRequired();

            builder.Property(b => b.SettlementId)
                .IsRequired();

            builder.Property(b => b.IsActive)
                .IsRequired()
                .HasDefaultValue(true);
        }
    }
}