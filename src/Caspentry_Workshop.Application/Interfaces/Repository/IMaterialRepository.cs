using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Caspentry_Workshop.Domain.Entities;

namespace Caspentry_Workshop.Application.Interfaces.Repository
{
    public interface IMaterialRepository
    {
        public Task AddMaterial(Material material);
        public Task EditMaterial(int id, Material dto);
        public Task<Material> GetByIdMaterial(int id);
        public Task<IEnumerable<Material>> GetAllMaterials();
        public Task RemoveMaterial(int id);
    }
}