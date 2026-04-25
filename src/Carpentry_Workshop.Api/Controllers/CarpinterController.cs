using Caspentry_Workshop.Application.DTOs.Carpinter;
using Caspentry_Workshop.Application.DTOs.CarpinterDTOs;
using Caspentry_Workshop.Application.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace Carpentry_Workshop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarpinterController : ControllerBase
    {
        private readonly ICarpinterService _service;

        public CarpinterController(ICarpinterService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCarpinterDto>>> GetAllCarpinters()
        {
            var carpinters = await _service.GetAllCarpinters();
            return Ok(carpinters);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetCarpinterDto>> GetByIdCarpinter(int id)
        {
            var carpinter = await _service.GetByIdCarpinter(id);
            return Ok(carpinter);
        }

        [HttpPost]
        public async Task<ActionResult> AddCarpinter(AddCarpinterDto dto)
        {
            if (dto is null) return NotFound();
            await _service.AddCarpinter(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCarpinter(int id, AddCarpinterDto dto)
        {
            await _service.EditCarpinter(id, dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveCarpinter(int id)
        {
            await _service.RemoveCanpinter(id);
            return Ok();
        }
    }
}