using Drones.Data.Entities;

namespace Drones.Data.Repositories
{
    public interface IDroneRepository
    {
        Task<Drone> GetByID(int id);
        Task<Drone> LoadDrone(int id, List<Medicament> medicaments);
        Task<Drone> RegisterDrone(Drone drone);
        Task<IEnumerable<Drone>> GetavAilable();
    }
}
