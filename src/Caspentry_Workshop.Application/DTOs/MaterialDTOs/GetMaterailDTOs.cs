using System.ComponentModel.DataAnnotations;

namespace Caspentry_Workshop.Application.DTOs.Material
{
    public class GetMaterialDto
    {
        [Required]
        public string? NombreMaterial { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Required]
        public double PrecioUnitario { get; set; }
        [Required]
        public string? ImageMaterial { get; set; }
    }
}