using SchoolRegister.Repositories.Users;


namespace SchoolRegister
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
