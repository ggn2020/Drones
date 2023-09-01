using Drones.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Drones.Data
{
    public class ApplicationDbContextInitialiser
    {
        private readonly DronesDbContext _context;

        public ApplicationDbContextInitialiser(DronesDbContext context)
        {
            _context = context;
        }

        public async Task InitializeAsync()
        {
            try
            {
                await _context.Database.MigrateAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task SeedAsync()
        {
            try
            {
                await TrySeedAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async Task TrySeedAsync()
        {
            if (!_context.Drones.Any())
            {
                var drons = new List<Drone> {
                    new Drone
                    {
                        CapacidadBateria=100,
                        Estado=EstadosDron.INACTIVO,
                        Modelo=ModelosDron.crucero,
                        NumeroSerie="QWE-456",
                        PesoLimite=350
                    },
                    new Drone
                    {
                        CapacidadBateria=20,
                        Estado=EstadosDron.INACTIVO,
                        Modelo=ModelosDron.ligero,
                        NumeroSerie="HVY-888",
                        PesoLimite=250
                    },
                    new Drone
                    {
                        CapacidadBateria=50,
                        Estado=EstadosDron.INACTIVO,
                        Modelo=ModelosDron.pesado,
                        NumeroSerie="UHVY-888",
                        PesoLimite=500
                    }
                };
                _context.Drones.AddRange(drons);
            }

            if (!_context.Medicamentos.Any())
            {
                var medicaments = new List<Medicament> {
                    new Medicament
                    {
                        Codigo="ASP_125",
                        Imagen="Resources\\Images\\asp.jpg",
                        Nombre="Aspirina",
                        Peso=25
                    },
                    new Medicament
                    {
                        Codigo="DRLG_200",
                        Imagen="Resources\\Images\\dur.jpg",
                        Nombre="Duralgina",
                        Peso=30
                    },
                    new Medicament
                    {
                        Codigo="VIT_C_500",
                        Imagen="Resources\\Images\\vit-c.jpg",
                        Nombre="Vitamina-C",
                        Peso=40
                    }
                };
                _context.Medicamentos.AddRange(medicaments);

                await _context.SaveChangesAsync();
            }
        }
    }
}
