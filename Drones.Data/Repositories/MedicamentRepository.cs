using Drones.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Drones.Data.Repositories
{
    public class MedicamentRepository : IMedicamentRepository
    {
        private readonly DronesDbContext _dbContext;

        public MedicamentRepository(DronesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Medicament> Create(Medicament medicament)
        {
            try
            {
                _dbContext.Medicamentos.Add(medicament);
                await _dbContext.SaveChangesAsync();
                return medicament;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Medicament> GetById(int id)
        {
            try
            {
                return await _dbContext.Medicamentos.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Medicament>> GetByIds(List<int> ids)
        {
            try
            {
                return await _dbContext.Medicamentos.Where(m => ids.Contains(m.Id)).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
