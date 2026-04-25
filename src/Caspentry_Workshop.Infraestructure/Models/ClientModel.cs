using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Caspentry_Workshop.Domain.Core;
namespace Caspentry_Workshop.Domain.Entities
{
    public class ClientModel : BaseEntity
    {
        public string? Name { get; set; }
        public string? Lastname { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public ICollection<Project> Proyects { get; set; } = new List<Project>();
    }
}