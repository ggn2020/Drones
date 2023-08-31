namespace Drones.Domain.Entities
{
    public class Drone
    {
        public int Id { get; set; }
        public string? NumeroSerie { get; set; }
        public ModelosDron Modelo { get; set; }
        public int PesoLimite { get; set; }
        public int CapacidadBateria { get; set; }
        public EstadosDron Estado { get; set; }
    }
}
