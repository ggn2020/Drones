using System.ComponentModel;

namespace Drones.Domain
{
    public enum EstadosDron
    {
        INACTIVO,
        CARGANDO,
        CARGADO,
        [Description("ENTREGANDO CARGA")]
        ENTREGANDO,
        [Description("CARGA ENTREGADA")]
        CARGAENTREGADA,
        REGRESANDO
    }
    public enum ModelosDron
    {
        [Description("Peso Ligero")]
        ligero,
        [Description("Peso Medio")]
        medio,
        [Description("Peso Crucero")]
        crucero,
        [Description("Peso Pesado")]
        pesado
    }
}