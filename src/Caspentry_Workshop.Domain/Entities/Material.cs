using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Caspentry_Workshop.Domain.Core;

namespace Caspentry_Workshop.Domain.Entities
{
    public class Material : BaseEntity
    {
        public string? nombreMaterial { get; set; }
        public int cantidad { get; set; }
        public string? ImageMaterial { get; set; }

        public double precioUnitario { get; set; }
    }
}