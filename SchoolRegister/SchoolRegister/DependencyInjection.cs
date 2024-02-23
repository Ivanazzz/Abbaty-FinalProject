using SchoolRegister.Repositories.People;
using SchoolRegister.Repositories.Schools;
using SchoolRegister.Repositories.Users;


namespace SchoolRegister
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<ISchoolRepository, SchoolRepository>()
                .AddScoped<IPersonRepository, PersonRepository>();

            return services;
        }
    }
}
