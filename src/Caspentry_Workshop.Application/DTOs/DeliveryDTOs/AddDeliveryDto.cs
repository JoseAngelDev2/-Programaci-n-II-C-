using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Caspentry_Workshop.Domain.Core;

namespace Caspentry_Workshop.Application.DTOs.DeliveryDTOs
{
    public class AddDeliveryDto : BaseEntity
    {
        [Required]
        public DateTime DeliveryDate { get; set; }
        [Required]
        public string? StatusDelivery { get; set; }
        [Required]
        public int ProjectId { get; set; }
    }
}