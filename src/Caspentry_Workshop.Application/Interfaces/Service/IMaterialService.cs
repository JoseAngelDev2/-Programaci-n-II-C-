using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Caspentry_Workshop.Application.DTOs.Material;
using Caspentry_Workshop.Application.DTOs.MaterialDTOs;
using Caspentry_Workshop.Domain.Entities;

namespace Caspentry_Workshop.Application.Interfaces.Service
{
    public interface IMaterialService
    {
        public Task AddMaterial(AddMaterialDto material);
        public Task EditMaterial(int id, AddMaterialDto material);
        public Task<GetMaterialDto> GetByIdMaterial(int id);
        public Task<IEnumerable<Material>> GetAllMaterials();
        public Task RemoveMaterial(int id);
    }
}