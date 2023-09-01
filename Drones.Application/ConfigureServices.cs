using Drones.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Drones.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IDroneService, DroneService>();
            services.AddScoped<IMedicamentService, MedicamentService>();
            return services;
        }
    }
}
