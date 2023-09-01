using AutoMapper;
using Drones.Application.Common.Models;
using Drones.Data.Entities;
using Drones.Data.Repositories;

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

        public async Task<MedicamentDto> Create(MedicamentForCreationDto medicament)
        {
            var result = await _repository.Create(_mapper.Map<Medicament>(medicament));
            return _mapper.Map<MedicamentDto>(result);
        }

        public async Task<MedicamentDto> GetById(int id)
        {
            var result = await _repository.GetById(id);
            return _mapper.Map<MedicamentDto>(result);
        }
    }
}
