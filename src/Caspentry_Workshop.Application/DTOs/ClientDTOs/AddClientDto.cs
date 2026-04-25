using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Caspentry_Workshop.Domain.Core;

namespace Caspentry_Workshop.Application.DTOs.CarpinterDTOs
{

    public class AddClientDto : BaseEntity
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Lastname { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public string? Phone { get; set; }
        [Required]
        public string? Email { get; set; }

    }

}