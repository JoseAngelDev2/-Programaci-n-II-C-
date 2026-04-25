using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Caspentry_Workshop.Domain.Entities;

namespace Caspentry_Workshop.Application.Interfaces.Repository
{
    public interface ICarpinterRepository
    {
        public Task AddCarpinter(Carpinter carpinter);
        public Task EditCarpinter(int id, Carpinter dto);
        public Task<Carpinter> GetByIdCarpinter(int id);
        public Task<IEnumerable<Carpinter>> GetAllCarpinters();
        public Task RemoveCarpinter(int id);
    }
}