using System.ComponentModel.DataAnnotations;
using Caspentry_Workshop.Domain.Core;

namespace Caspentry_Workshop.Application.DTOs.Project
{
    public class GetProjectDto : BaseEntity
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