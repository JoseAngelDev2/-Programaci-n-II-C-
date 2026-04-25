using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Caspentry_Workshop.Domain.Core;

namespace Caspentry_Workshop.Application.DTOs.ProjectDTOs
{
    public class AddProjectDto : BaseEntity
    {
        [Required]
        public string? NameProyect { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public string? Status { get; set; }
        [Required]
        public double Total { get; set; }
        [Required]
        public int ClienteId { get; set; }
    }
}