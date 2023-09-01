using Drones.Data;
using System.ComponentModel.DataAnnotations;

namespace Drones.Application.Common.Models
{
    public class DroneForCreationDto
    {
        [MaxLength(100)]
        [Required]
        public string? NumeroSerie { get; set; }
        [Required]
        public ModelosDron Modelo { get; set; }
        [Required]
        [Range(1, 500)]
        public int PesoLimite { get; set; }
        [Required]
        [Range(1, 100)]
        public int CapacidadBateria { get; set; }
        [Required]
        public EstadosDron Estado { get; set; }
    }
}
