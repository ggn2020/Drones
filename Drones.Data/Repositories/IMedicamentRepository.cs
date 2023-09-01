using Drones.Data.Entities;

namespace Drones.Data.Repositories
{
    public interface IMedicamentRepository
    {
        Task<Medicament> GetById(int id);
        Task<List<Medicament>> GetByIds(List<int> ids);
        Task<Medicament> Create(Medicament medicament);
    }
}
