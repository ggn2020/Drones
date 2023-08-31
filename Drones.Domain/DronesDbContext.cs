using Drones.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Drones.Domain
{
    public class DronesDbContext : DbContext
    {
        public DronesDbContext(DbContextOptions<DronesDbContext> options) : base(options)
        {

        }

        public DbSet<Drone> Drones { get; set; }
        public DbSet<Medicament> Medicamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
