using Drones.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Drones.Data.Configurations
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
            builder.HasMany(e => e.Medicaments).WithMany();
        }
    }

    public class MedicamentConf : IEntityTypeConfiguration<Medicament>
    {
        public void Configure(EntityTypeBuilder<Medicament> builder)
        {
            builder.Property(m => m.Peso).IsRequired();
            builder.Property(m => m.Nombre).IsRequired();
            builder.Property(m => m.Imagen).IsRequired();
            builder.Property(m => m.Codigo).IsRequired();
        }
    }
}
