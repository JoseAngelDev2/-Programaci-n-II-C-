using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Caspentry_Workshop.Domain.Core;

namespace Caspentry_Workshop.Domain.Entities
{
    public class MaterialModel : BaseEntity
    {

        public string? nombreMaterial { get; set; }
        public int cantidad { get; set; }
        public double precioUnitario { get; set; }
        public string? ImageMaterial { get; set; }
    }
}