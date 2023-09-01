using System.ComponentModel.DataAnnotations;

namespace Drones.Application.Common.Models
{
    public class MedicamentForCreationDto
    {
        [Required]
        [RegularExpression("^[a-zA-Z0-9_-]*$", ErrorMessage = "permitido solo letras, números, ‘-‘, ‘_’")]
        public string? Nombre { get; set; }
        [Required]
        public int Peso { get; set; }
        [Required]
        [RegularExpression("^[A-Z0-9_]*$", ErrorMessage = "permitido solo letra mayúscula, guión bajo y números")]
        public string? Codigo { get; set; }
        public string? Imagen { get; set; }
    }
}
