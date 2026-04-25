using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Caspentry_Workshop.Domain.Core;

namespace Caspentry_Workshop.Application.DTOs.ClientDTOs
{

    public class GetClientDto : BaseEntity
    {
        public string? Name { get; set; }
        public string? Lastname { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
    }

}