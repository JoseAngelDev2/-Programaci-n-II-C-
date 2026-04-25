using Caspentry_Workshop.Application.DTOs.CarpinterDTOs;
using Caspentry_Workshop.Application.DTOs.ClientDTOs;
using Caspentry_Workshop.Application.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace Carpentry_Workshop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _service;

        public ClientController(IClientService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetClientDto>>> GetAllClients()
        {
            var clients = await _service.GetAllClients();
            return Ok(clients);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetClientDto>> GetByIdClient(int id)
        {
            var client = await _service.GetByIdClient(id);
            
            return Ok(client);
        }

        [HttpPost]
        public async Task<ActionResult> AddClient(AddClientDto dto)
        {
            if (dto is null) return NotFound();
            await _service.AddClient(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateClient(int id, AddClientDto dto)
        {
            await _service.EditClient(id, dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveClient(int id)
        {
            await _service.RemoveClient(id);
            return Ok();
        }
    }
}