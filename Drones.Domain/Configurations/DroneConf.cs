using Drones.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Drones.Domain.Configurations
{
    public class DroneConf : IEntityTypeConfiguration<Drone>
    {
        public void Configure(EntityTypeBuilder<Drone> builder)
        {
            builder.Property(n => n.NumeroSerie).HasMaxLength(100)
                .IsRequired();
            builder.Property(n => n.Modelo)
                .IsRequired();
            builder.Property(n => n.Estado)
                .IsRequired();
            builder.Property(n => n.PesoLimite)
                .IsRequired();
            builder.Property(n => n.CapacidadBateria)
                .IsRequired();
        }
    }
}
