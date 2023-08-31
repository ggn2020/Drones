using Drones.Application.Common.Models;
using Drones.Domain.Entities;

namespace Drones.Application.Services
{
    public interface IDroneService
    {
        Task<IEnumerable<DroneDto>> GetAvailable();
        Task<int> GetBatteryLevel(int id);
        Task<int> CheckLoadedWeight(int id);
        Task<DroneDto> Register(DroneDto drone);
        Task<DroneDto> LoadDrone(int id, List<Medicament> medicaments);
    }
}
