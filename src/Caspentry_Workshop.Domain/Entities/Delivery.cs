using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Caspentry_Workshop.Domain.Core;

namespace Caspentry_Workshop.Domain.Entities
{
    public class Delivery : BaseEntity
    {
        public DateTime deliveryDate { get; set; }
        public string? statusDelivery { get; set; } // Pendiente, Entregado
        public Project? Project { get; set; }
        public int ProjectId { get; set; }
    }
}