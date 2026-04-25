using System.ComponentModel.DataAnnotations;
using Caspentry_Workshop.Domain.Core;

namespace Caspentry_Workshop.Application.DTOs.Delivery
{


    public class GetDeliveryDto : BaseEntity
    {
        [Required]
        public DateTime DeliveryDate { get; set; }
        [Required]
        public string? StatusDelivery { get; set; }
        [Required]
        public int ProjectId { get; set; }
    }
}