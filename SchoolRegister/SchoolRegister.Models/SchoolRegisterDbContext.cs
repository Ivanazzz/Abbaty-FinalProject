using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SchoolRegister.Models.Common;
using SchoolRegister.Models.Entities;
using System.Security.Claims;

namespace SchoolRegister.Models
{
    public class SchoolRegisterDbContext : DbContext
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public SchoolRegisterDbContext(DbContextOptions<SchoolRegisterDbContext> options, IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public DbSet<Person> Persons { get; set; }

        public DbSet<PersonHistory> PersonHistories { get; set; }

        public DbSet<PersonSchool> PersonSchools { get; set; }

        public DbSet<School> Schools { get; set; }

        public DbSet<Settlement> Settlements { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                // Configure name mappings
                entity.SetTableName(entity.ClrType.Name.ToLower());
                if (typeof(IEntity).IsAssignableFrom(entity.ClrType))
                {
                    modelBuilder.Entity(entity.ClrType)
                        .HasKey(nameof(IEntity.Id));
                }

                entity.GetProperties()
                    .ToList()
                    .ForEach(e => e.SetColumnName(e.Name.ToLower()));
                entity.GetForeignKeys()
                    .Where(e => !e.IsOwnership && e.DeleteBehavior == DeleteBehavior.Cascade)
                    .ToList()
                    .ForEach(e => e.DeleteBehavior = DeleteBehavior.Restrict);
            }
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SchoolRegisterDbContext).Assembly);
        }

        public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            return Database.BeginTransactionAsync(cancellationToken);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var username = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;
            var user = await Users.FirstOrDefaultAsync(u => u.Username == username && u.IsActive == true);

            foreach (var entry in ChangeTracker.Entries())
            {
                if (typeof(IAuditable).IsAssignableFrom(entry.Entity.GetType()) && entry.State == EntityState.Added)
                {
                    var entity = entry.Entity as IAuditable;
                    entity.CreateDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
                    entity.CreatorUserId = user == null
                        ? 0
                        : user.Id;
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}