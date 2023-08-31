using AutoMapper;
using Drones.Application.Common.Models;
using Drones.Domain.Entities;
using Drones.Domain.Repositories;

namespace Drones.Application.Services
{
    public class DroneService : IDroneService
    {
        private readonly IDroneRepository _repository;
        private readonly IMapper _mapper;

        public DroneService(IMapper mapper, IDroneRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public Task<int> CheckLoadedWeight(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<DroneDto>> GetAvailable()
        {
            var result = await _repository.GetavAilable();
            return _mapper.Map<IEnumerable<DroneDto>>(result);
        }

        public Task<int> GetBatteryLevel(int id)
        {
            throw new NotImplementedException();
        }

        public Task<DroneDto> LoadDrone(int id, List<Medicament> medicaments)
        {
            throw new NotImplementedException();
        }

        public Task<DroneDto> Register(DroneDto drone)
        {
            throw new NotImplementedException();
        }
    }
}
