using Drones.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Drones.Domain
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DronesDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    builder => builder.MigrationsAssembly(typeof(DronesDbContext).Assembly.FullName)));

            //services.AddScoped<DronesDbContext>(provider => provider.GetRequiredService<DronesDbContext>());
            services.AddScoped<IDroneRepository, DroneRepository>();

            return services;
        }
    }
}
