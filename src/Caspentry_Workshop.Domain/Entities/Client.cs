using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Caspentry_Workshop.Domain.Core;
namespace Caspentry_Workshop.Domain.Entities
{
    public class Client : BaseEntity
    {
        public string? Name { get; set; }
        public string? Lastname { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        [JsonIgnore]
        public ICollection<Project> Proyects { get; set; } = new List<Project>();
    }
}