using AutoMapper;
using Drones.Application.Common.Models;
using Drones.Data.Entities;

namespace Drones.Application.Common.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Drone, DroneDto>().ReverseMap();
            CreateMap<Drone, DroneForCreationDto>().ReverseMap();
            CreateMap<Medicament, MedicamentForCreationDto>().ReverseMap();
            CreateMap<Medicament, MedicamentDto>().ReverseMap();
        }
    }
}
