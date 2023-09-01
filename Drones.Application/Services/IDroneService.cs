using Drones.Application.Common.Models;

namespace Drones.Application.Services
{
    public interface IDroneService
    {
        Task<ApiResponse<IEnumerable<DroneDto>>> GetAvailable();
        Task<ApiResponse<int>> GetBatteryLevel(int id);
        Task<ApiResponse<DroneDto>> GetById(int id);
        Task<ApiResponse<int>> CheckLoadedWeight(int id);
        Task<ApiResponse<DroneDto>> Register(DroneForCreationDto drone);
        Task<ApiResponse<DroneDto>> LoadDrone(int id, List<int> medicaments);
    }
}
