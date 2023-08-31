using Drones.Domain.Entities;

namespace Drones.Domain.Repositories
{
    public interface IDroneRepository
    {
        Task<Drone> GetByID(int id);
        Task<Drone> LoadDrone(int id, List<Medicament> medicaments);
        Task<Drone> RegisterDrone(Drone drone);
        Task<IEnumerable<Drone>> GetavAilable();
    }
}
