using Drones.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Drones.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Drone> Drones { get; }
        DbSet<Medicament> Medicamentos { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
