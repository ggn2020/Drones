using Drones.Application.Common.Models;

namespace Drones.Application.Services
{
    public interface IMedicamentService
    {
        Task<MedicamentDto> Create(MedicamentForCreationDto medicament);
        Task<MedicamentDto> GetById(int id);
    }
}
