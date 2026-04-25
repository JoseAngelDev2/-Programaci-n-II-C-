using Caspentry_Workshop.Application.DTOs.Delivery;
using Caspentry_Workshop.Application.DTOs.DeliveryDTOs;
using Caspentry_Workshop.Application.Interfaces.Service;
using Caspentry_Workshop.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Carpentry_Workshop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        private readonly IDeliveryService _service;

        public DeliveryController(IDeliveryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetDeliveryDto>>> GetAllDeliveries()
        {
            var deliveries = await _service.GetAllDeliverys();
            return Ok(deliveries);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetDeliveryDto>> GetByIdDelivery(int id)
        {
            var delivery = await _service.GetByIdDelivery(id);
            return Ok(delivery);
        }

        [HttpPost]
        public async Task<ActionResult> AddDelivery(AddDeliveryDto dto)
        {
            if (dto is null) return NotFound();
            await _service.AddDelivery(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDelivery(int id, AddDeliveryDto dto)
        {
            await _service.EditDelivery(id, dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveDelivery(int id)
        {
            await _service.RemoveDelivery(id);
            return Ok();
        }
    }
}