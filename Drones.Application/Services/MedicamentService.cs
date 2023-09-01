using AutoMapper;
using Drones.Application.Common.Models;
using Drones.Data.Entities;
using Drones.Data.Repositories;
using System.Net;

namespace Drones.Application.Services
{
    public class MedicamentService : IMedicamentService
    {
        private readonly IMedicamentRepository _repository;
        private readonly IMapper _mapper;

        public MedicamentService(IMedicamentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<MedicamentDto>> Create(MedicamentForCreationDto medicament)
        {
            try
            {
                var result = await _repository.Create(_mapper.Map<Medicament>(medicament));
                return new ApiResponse<MedicamentDto> { Data = _mapper.Map<MedicamentDto>(result), Code = HttpStatusCode.Created };
            }
            catch (Exception ex)
            {
                return new ApiResponse<MedicamentDto> { Success = false, Error = ex.Message, Code = HttpStatusCode.InternalServerError };
            }
        }

        public async Task<ApiResponse<MedicamentDto>> GetById(int id)
        {
            try
            {
                var result = await _repository.GetById(id);
                if (result is null) return new ApiResponse<MedicamentDto> { Success = false, Error = "Medicamento no encontrado", Code = HttpStatusCode.NotFound };
                return new ApiResponse<MedicamentDto> { Data = _mapper.Map<MedicamentDto>(result) };

            }
            catch (Exception ex)
            {
                return new ApiResponse<MedicamentDto> { Success = false, Error = ex.Message, Code = HttpStatusCode.InternalServerError };
            }
        }
    }
}
