using Drones.Application.Common.Models;

namespace Drones.Application.Services
{
    public interface IMedicamentService
    {
        Task<ApiResponse<MedicamentDto>> Create(MedicamentForCreationDto medicament);
        Task<ApiResponse<MedicamentDto>> GetById(int id);
    }
}
