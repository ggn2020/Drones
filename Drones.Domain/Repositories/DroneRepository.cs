using Drones.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Drones.Domain.Repositories
{
    public class DroneRepository : IDroneRepository
    {
        private readonly DronesDbContext _context;

        public DroneRepository(DronesDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Drone>> GetavAilable()
        {
            var result = await _context.Drones.Where(d => d.Estado == EstadosDron.INACTIVO
            && d.CapacidadBateria >= 25).ToListAsync();

            return result;
        }

        public Task<Drone> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Drone> LoadDrone(int id, List<Medicament> medicaments)
        {
            throw new NotImplementedException();
        }

        public Task<Drone> RegisterDrone(Drone drone)
        {
            throw new NotImplementedException();
        }
    }
}
