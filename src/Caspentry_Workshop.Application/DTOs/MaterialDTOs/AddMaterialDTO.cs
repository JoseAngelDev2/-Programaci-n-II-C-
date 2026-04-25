using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Caspentry_Workshop.Application.DTOs.MaterialDTOs
{
    public class AddMaterialDto
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