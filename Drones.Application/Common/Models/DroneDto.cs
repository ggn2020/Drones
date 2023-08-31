using Drones.Domain;

namespace Drones.Application.Common.Models
{
    public class DroneDto
    {
        public int Id { get; set; }
        public string? NumeroSerie { get; set; }
        public ModelosDron Modelo { get; set; }
        public int PesoLimite { get; set; }
        public int CapacidadBateria { get; set; }
        public EstadosDron Estado { get; set; }
    }
}
