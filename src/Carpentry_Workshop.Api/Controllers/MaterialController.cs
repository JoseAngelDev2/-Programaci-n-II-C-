using Caspentry_Workshop.Application.DTOs.Material;
using Caspentry_Workshop.Application.DTOs.MaterialDTOs;
using Caspentry_Workshop.Application.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace Carpentry_Workshop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialService _service;

        public MaterialController(IMaterialService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetMaterialDto>>> GetAllMaterials()
        {
            var materials = await _service.GetAllMaterials();
            return Ok(materials);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetMaterialDto>> GetByIdMaterial(int id)
        {
            var material = await _service.GetByIdMaterial(id);
            return Ok(material);
        }

        [HttpPost]
        public async Task<ActionResult> AddMaterial(AddMaterialDto dto)
        {
            if (dto is null) return NotFound();
            await _service.AddMaterial(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMaterial(int id, AddMaterialDto dto)
        {
            await _service.EditMaterial(id, dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveMaterial(int id)
        {
            await _service.RemoveMaterial(id);
            return Ok();
        }
    }
}