using Caspentry_Workshop.Application.DTOs.Material;
using Caspentry_Workshop.Application.DTOs.MaterialDTOs;
using Caspentry_Workshop.Application.Interfaces.Repository;
using Caspentry_Workshop.Application.Interfaces.Service;
using Caspentry_Workshop.Domain.Entities;

namespace Caspentry_Workshop.Application.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly IMaterialRepository _repository;

        public MaterialService(IMaterialRepository repository)
        {
            _repository = repository;
        }

        public async Task AddMaterial(AddMaterialDto dto)
        {
            var material = new Material
            {
                nombreMaterial = dto.NombreMaterial,
                cantidad = dto.Cantidad,
                precioUnitario = dto.PrecioUnitario,
                ImageMaterial = dto.ImageMaterial
            };
            await _repository.AddMaterial(material);
        }

        public async Task EditMaterial(int id, AddMaterialDto dto)
        {
            var material = new Material
            {
                nombreMaterial = dto.NombreMaterial,
                cantidad = dto.Cantidad,
                precioUnitario = dto.PrecioUnitario,
                ImageMaterial = dto.ImageMaterial
            };
            
            await _repository.EditMaterial(id, material);
        }

        public async Task<IEnumerable<Material>> GetAllMaterials()
        {
            var materials = await _repository.GetAllMaterials();
            return materials;
        }

        public async Task<GetMaterialDto> GetByIdMaterial(int id)
        {
            var material = await _repository.GetByIdMaterial(id);
            return new GetMaterialDto
            {
                NombreMaterial = material.nombreMaterial,
                Cantidad = material.cantidad,
                PrecioUnitario = material.precioUnitario,
                ImageMaterial = material.ImageMaterial
            };
        }

        public async Task RemoveMaterial(int id)
        {
            await _repository.RemoveMaterial(id);
        }
    }
}