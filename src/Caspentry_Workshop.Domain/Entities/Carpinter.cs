using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Caspentry_Workshop.Domain.Core;

namespace Caspentry_Workshop.Domain.Entities
{
    public class Carpinter : BaseEntity
    {
        public string? Name { get; set; }
        public string? Specialty { get; set; }
        public string? Phone { get; set; }
        public double Salary { set; get; }
    }
}
