using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Caspentry_Workshop.Application.DTOs.CarpinterDTOs
{

    public class AddCarpinterDto
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