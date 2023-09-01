using AutoMapper;
using Drones.Application.Common.Mappings;
using Drones.Application.Common.Models;
using Drones.Application.Services;
using Drones.Data;
using Drones.Data.Entities;
using Drones.Data.Repositories;
using Moq;
using System.Net;

namespace Drones.Tests.Services
{
    public class DroneServiceTests
    {
        private static IMapper _mapper;
        private readonly Mock<IDroneRepository> _dronRepo;
        private readonly Mock<IMedicamentRepository> _medicamentRepo;
        private readonly DroneService _droneService;

        public DroneServiceTests()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MappingProfiles());
                });
                _mapper = mappingConfig.CreateMapper();
            }

            _medicamentRepo = new Mock<IMedicamentRepository>();
            _dronRepo = new Mock<IDroneRepository>();
            _droneService = new DroneService(_mapper, _dronRepo.Object, _medicamentRepo.Object);
        }

        [Fact]
        public void GetById_CorrectId_ReturnsCorrectType()
        {
            int id = 1;
            var drone = new Drone();
            _dronRepo.Setup(r => r.GetByID(id))
                .Returns(Task.FromResult(drone));
            var result = _droneService.GetById(id).Result;
            Assert.IsAssignableFrom<ApiResponse<DroneDto>>(result);
        }

        [Fact]
        public void GetById_CorrectId_ReturnsCorrectDrone()
        {
            int id = 1;
            var drone = new Drone { Id = id, CapacidadBateria = 100, Estado = 0, Modelo = 0, NumeroSerie = "JUYT-313", PesoLimite = 400 };
            _dronRepo.Setup(r => r.GetByID(id))
                .Returns(Task.FromResult(drone));
            var result = _droneService.GetById(drone.Id).Result;
            Assert.Equal(id, result.Data.Id);
        }
        [Fact]
        public void GetById_InvalidId_ReturnsNotFoud()
        {
            int id = 1;
            Drone drone = null;
            _dronRepo.Setup(r => r.GetByID(id))
                .Returns(Task.FromResult(drone));
            var result = _droneService.GetById(id).Result;
            Assert.Null(result.Data);
            Assert.Equal(HttpStatusCode.NotFound, result.Code);
        }
        [Fact]
        public void GetById_OnError_ReturnsExceptionError()
        {
            var exception = new Exception("error");

            _dronRepo.Setup(r => r.GetByID(1))
            .Throws(exception);

            var result = _droneService.GetById(1).Result;

            Assert.Equal(result.Error, exception.Message);
        }
        [Fact]
        public void GetAvailable_Returns_AvailableDrons()
        {
            IEnumerable<Drone> drons = new List<Drone> {
                new Drone{ Id = 1, CapacidadBateria=100, Estado=EstadosDron.INACTIVO,Modelo=0},
                new Drone{ Id = 2, CapacidadBateria=90, Estado=EstadosDron.INACTIVO,Modelo=0},
                new Drone{ Id = 3, CapacidadBateria=100, Estado=EstadosDron.INACTIVO,Modelo=0}
            };

            _dronRepo.Setup(r => r.GetavAilable()).Returns(Task.FromResult(drons));

            var result = _droneService.GetAvailable().Result;

            Assert.IsAssignableFrom<ApiResponse<IEnumerable<DroneDto>>>(result);
            Assert.NotNull(result.Data);
            Assert.Equal(3, result.Data.Count());
            Assert.Equal(1, result.Data.FirstOrDefault().Id);
        }
    }
}
