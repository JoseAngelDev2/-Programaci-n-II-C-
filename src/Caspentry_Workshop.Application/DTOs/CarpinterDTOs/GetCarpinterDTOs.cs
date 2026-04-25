using System.ComponentModel.DataAnnotations;

namespace Caspentry_Workshop.Application.DTOs.Carpinter
{
    public class GetCarpinterDto
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Specialty { get; set; }
        [Required]
        public string? Phone { get; set; }
        [Required]
        public double Salary { get; set; }
    }
}