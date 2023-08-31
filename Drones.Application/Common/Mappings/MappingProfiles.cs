using AutoMapper;
using Drones.Application.Common.Models;
using Drones.Domain.Entities;

namespace Drones.Application.Common.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Drone, DroneDto>().ReverseMap();
        }
    }
}
