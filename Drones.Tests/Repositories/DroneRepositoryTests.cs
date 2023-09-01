using Drones.Data;
using Drones.Data.Entities;
using Drones.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Drones.Tests.Repositories
{
    public class DroneRepositoryTests : IDisposable
    {
        private readonly DbContextOptions<DronesDbContext> _options;
        private readonly DronesDbContext _context;
        private readonly DroneRepository _repository;
        public DroneRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<DronesDbContext>()
                 .UseInMemoryDatabase(databaseName: "dronesdb")
                 .Options;

            _context = new DronesDbContext(_options);
            _repository = new DroneRepository(_context);

        }


        [Fact]
        public void GetAvailable_Returns_AvailableDrons()
        {
            var drons = new List<Drone> {
                new Drone{ Id = 1, CapacidadBateria=100, Estado=EstadosDron.INACTIVO,Modelo=0, NumeroSerie="SD-908", PesoLimite=450},
                new Drone{ Id = 2, CapacidadBateria=10, Estado=EstadosDron.INACTIVO,Modelo=0,NumeroSerie="SD-906", PesoLimite=200},
                new Drone{ Id = 3, CapacidadBateria=100, Estado=EstadosDron.CARGADO,Modelo=0,NumeroSerie="SD-900", PesoLimite=150}
            };

            _context.Drones.AddRange(drons);
            _context.SaveChanges();

            var result = _repository.GetavAilable().Result;
            Assert.NotNull(result);
            Assert.Equal(1, result.Count());
            Dispose();
        }
        [Fact]
        public void RegisterDrone_ValidData_AddDrone()
        {
            var drone = new Drone { Id = 1, CapacidadBateria = 100, Estado = EstadosDron.INACTIVO, Modelo = 0, NumeroSerie = "SD-918", PesoLimite = 450 };

            var result = _repository.RegisterDrone(drone).Result;
            Assert.NotNull(result);
            Dispose();
        }
        [Fact]
        public void RegisterDrone_InvalidData_DontAddDrone()
        {
            var drone = new Drone { Id = 1, CapacidadBateria = 100, Estado = EstadosDron.INACTIVO, Modelo = 0 };

            try
            {
                Assert.Throws<AggregateException>(() => _repository.RegisterDrone(drone).Result);
            }
            catch (Exception)
            {

            }
            Assert.Equal(0, _context.Drones.Count());

            Dispose();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
