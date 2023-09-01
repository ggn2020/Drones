using Drones.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Drones.Data
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DronesDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    builder => builder.MigrationsAssembly(typeof(DronesDbContext).Assembly.FullName)));

            //services.AddScoped<DronesDbContext>(provider => provider.GetRequiredService<DronesDbContext>());
            services.AddScoped<IDroneRepository, DroneRepository>();
            services.AddScoped<IMedicamentRepository, MedicamentRepository>();

            return services;
        }
    }
}
