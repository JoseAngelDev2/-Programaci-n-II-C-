using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Caspentry_Workshop.Domain.Core;

namespace Caspentry_Workshop.Domain.Entities
{
    public class Project : BaseEntity
    {
        public string? NameProyect { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public double Total { get; set; }
        public int ClienteId { get; set; }

    }
}