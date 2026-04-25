using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Caspentry_Workshop.Application.Interfaces.Repository;
using Caspentry_Workshop.Domain.Entities;
using Caspentry_Workshop.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Caspentry_Workshop.Infraestructure.Repositories
{
    public class MaterialRepository : IMaterialRepository
    {
        private readonly DbContextCapentryWorkshop _db;

        public MaterialRepository(DbContextCapentryWorkshop db)
        {
            _db = db;
        }

        public async Task AddMaterial(Material material)
        {
            var newMaterial = new MaterialModel
            {
                nombreMaterial = material.nombreMaterial,
                cantidad = material.cantidad,
                precioUnitario = material.precioUnitario,
                ImageMaterial = material.ImageMaterial
            };

            await _db.Materials.AddAsync(newMaterial);
            await SAVE();
        }

        public async Task EditMaterial(int id, Material material)
        {
            var foundMaterial = await _db.Materials.FindAsync(id);

            if (foundMaterial is null)
                throw new Exception($"Material with id {id} not found");

            foundMaterial.nombreMaterial = material.nombreMaterial;
            foundMaterial.cantidad = material.cantidad;
            foundMaterial.precioUnitario = material.precioUnitario;
            foundMaterial.ImageMaterial = material.ImageMaterial;

            await SAVE();
        }

        public async Task<IEnumerable<Material>> GetAllMaterials()
        {
            var materials = await _db.Materials.AsNoTracking().ToListAsync();

            return materials.Select(x => new Material
            {
                Id = x.Id,
                nombreMaterial = x.nombreMaterial,
                cantidad = x.cantidad,
                precioUnitario = x.precioUnitario,
                ImageMaterial = x.ImageMaterial

            }).ToList();
        }

        public async Task<Material> GetByIdMaterial(int id)
        {
            var foundMaterial = await _db.Materials.FindAsync(id);

            return new Material
            {
                Id = foundMaterial!.Id,
                nombreMaterial = foundMaterial.nombreMaterial,
                cantidad = foundMaterial.cantidad,
                precioUnitario = foundMaterial.precioUnitario,
                ImageMaterial = foundMaterial.ImageMaterial
            };
        }

        public async Task RemoveMaterial(int id)
        {
            var foundMaterial = await _db.Materials.FindAsync(id);

            if (foundMaterial is null)
            {
                Console.WriteLine("The material has not been found");
                return;
            }

            _db.Materials.Remove(foundMaterial);
            await SAVE();
        }

        public async Task SAVE()
        {
            await _db.SaveChangesAsync();
        }
    }
}