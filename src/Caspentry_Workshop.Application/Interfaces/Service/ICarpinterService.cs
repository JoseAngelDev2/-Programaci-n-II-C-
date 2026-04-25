using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Caspentry_Workshop.Application.DTOs.Carpinter;
using Caspentry_Workshop.Application.DTOs.CarpinterDTOs;
using Caspentry_Workshop.Domain.Entities;

namespace Caspentry_Workshop.Application.Interfaces.Service
{
    public interface ICarpinterService
    {
        public Task AddCarpinter(AddCarpinterDto carpinter);
        public Task EditCarpinter(int id, AddCarpinterDto carpinter);
        public Task<GetCarpinterDto> GetByIdCarpinter(int id);
        public Task<IEnumerable<Carpinter>> GetAllCarpinters();
        public Task RemoveCanpinter(int id);
    }
}