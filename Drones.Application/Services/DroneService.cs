using AutoMapper;
using Drones.Application.Common.Models;
using Drones.Data;
using Drones.Data.Entities;
using Drones.Data.Repositories;
using System.Net;

namespace Drones.Application.Services
{
    public class DroneService : IDroneService
    {
        private readonly IDroneRepository _repository;
        private readonly IMedicamentRepository _Medrepository;
        private readonly IMapper _mapper;

        public DroneService(IMapper mapper, IDroneRepository repository, IMedicamentRepository medrepository)
        {
            _mapper = mapper;
            _repository = repository;
            _Medrepository = medrepository;
        }

        public async Task<ApiResponse<int>> CheckLoadedWeight(int id)
        {
            try
            {
                var drone = await _repository.GetByID(id);
                if (drone is not null)
                {
                    return new ApiResponse<int> { Data = drone.Medicaments.Sum(x => x.Peso) };
                }
                return new ApiResponse<int> { Success = false, Code = HttpStatusCode.NotFound, Error = "Dron no encontrado" };

            }
            catch (Exception ex)
            {
                return new ApiResponse<int> { Success = false, Error = ex.Message };
            }
        }

        public async Task<ApiResponse<IEnumerable<DroneDto>>> GetAvailable()
        {
            try
            {
                var result = await _repository.GetavAilable();
                if (result is not null && result.Count() > 0) return new ApiResponse<IEnumerable<DroneDto>> { Data = _mapper.Map<IEnumerable<DroneDto>>(result) };

                return new ApiResponse<IEnumerable<DroneDto>> { Code = HttpStatusCode.NotFound, Error = "No hay drones disponibles", Success = false };
            }
            catch (Exception ex)
            {
                return new ApiResponse<IEnumerable<DroneDto>> { Code = HttpStatusCode.InternalServerError, Error = ex.Message, Success = false };
            }
        }

        public async Task<ApiResponse<int>> GetBatteryLevel(int id)
        {
            try
            {
                var drone = await _repository.GetByID(id);
                if (drone is null) return new ApiResponse<int> { Success = false, Code = HttpStatusCode.NotFound, Error = "Dron no encontrado" };
                return new ApiResponse<int> { Data = drone.CapacidadBateria };
            }
            catch (Exception ex)
            {
                return new ApiResponse<int> { Code = HttpStatusCode.InternalServerError, Error = ex.Message, Success = false };
            }
        }

        public async Task<ApiResponse<DroneDto>> GetById(int id)
        {
            try
            {
                var result = await _repository.GetByID(id);
                if (result is null) return new ApiResponse<DroneDto> { Success = false, Error = "Dron no encontrado", Code = HttpStatusCode.NotFound };
                return new ApiResponse<DroneDto> { Data = _mapper.Map<DroneDto>(result) };
            }
            catch (Exception ex)
            {
                return new ApiResponse<DroneDto> { Error = ex.Message, Success = false, Code = HttpStatusCode.InternalServerError };
            }
        }

        public async Task<ApiResponse<DroneDto>> LoadDrone(int id, List<int> medicaments)
        {
            try
            {
                var medicamentsToAdd = await _Medrepository.GetByIds(medicaments);
                var drone = await _repository.GetByID(id);

                if (drone == null)
                    return new ApiResponse<DroneDto>() { Success = false, Error = "Dron no encontrado", Code = HttpStatusCode.NotFound };
                if (!IsDroneReady(drone, medicamentsToAdd))
                    return new ApiResponse<DroneDto> { Success = false, Data = _mapper.Map<DroneDto>(drone), Error = "El dron no está disponible", Code = HttpStatusCode.BadRequest };

                drone = await _repository.LoadDrone(id, medicamentsToAdd);

                return new ApiResponse<DroneDto> { Data = _mapper.Map<DroneDto>(drone), Code = HttpStatusCode.OK };
            }
            catch (Exception ex)
            {
                return new ApiResponse<DroneDto> { Success = false, Error = ex.Message, Code = HttpStatusCode.InternalServerError };
            }
        }

        public async Task<ApiResponse<DroneDto>> Register(DroneForCreationDto drone)
        {
            try
            {
                var result = await _repository.RegisterDrone(_mapper.Map<Drone>(drone));
                return new ApiResponse<DroneDto> { Data = _mapper.Map<DroneDto>(result) };
            }
            catch (Exception ex)
            {
                return new ApiResponse<DroneDto> { Success = false, Error = ex.Message, Code = HttpStatusCode.InternalServerError };
            }
        }

        private bool IsDroneReady(Drone drone, List<Medicament> medicaments)
        {
            var totalWeight = medicaments.Sum(x => x.Peso);
            if (drone.CapacidadBateria >= 25 && drone.Estado == EstadosDron.INACTIVO && drone.PesoLimite >= totalWeight) return true;
            return false;
        }
    }
}
