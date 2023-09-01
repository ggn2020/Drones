using Drones.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Drones.Data.Repositories
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

        public async Task<Drone> GetByID(int id)

        {
            return await _context.Drones.Include(d => d.Medicaments).FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Drone> LoadDrone(int id, List<Medicament> medicaments)
        {
            var drone = await _context.Drones.FindAsync(id);
            //drone.Estado = EstadosDron.CARGADO;
            drone.Medicaments.AddRange(medicaments);
            await _context.SaveChangesAsync();
            return drone;
        }

        public async Task<Drone> RegisterDrone(Drone drone)
        {
            _context.Drones.Add(drone);
            await _context.SaveChangesAsync();
            return drone;
        }
    }
}
