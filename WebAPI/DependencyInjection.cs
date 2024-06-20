using Microsoft.EntityFrameworkCore;
using WebAPI.Infrastructure.Entities;
using WebAPI.Infrastructure.Interfaces;
using WebAPI.Infrastructure.Persistence;
using WebAPI.Infrastructure.Services;

namespace WebAPI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppEFContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("AppConnection")));

            services.AddScoped<IAppEFContext>(provider => provider.GetService<AppEFContext>());

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Candidate>, CandidateRepository>();
            services.AddScoped<ICandidateService, CandidateService>();

            return services;
        }
    }
}