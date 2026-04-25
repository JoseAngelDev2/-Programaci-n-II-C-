using Caspentry_Workshop.Application.DTOs.Delivery;
using Caspentry_Workshop.Application.DTOs.DeliveryDTOs;
using Caspentry_Workshop.Application.Interfaces.Repository;
using Caspentry_Workshop.Application.Interfaces.Service;
using Caspentry_Workshop.Domain.Entities;

namespace Caspentry_Workshop.Application.Services
{
    public class DeliveryService : IDeliveryService
    {
        private readonly IDeliveryRepository _repository;

        public DeliveryService(IDeliveryRepository repository)
        {
            _repository = repository;
        }

        public async Task AddDelivery(AddDeliveryDto dto)
        {
            var delivery = new Delivery
            {
                deliveryDate = dto.DeliveryDate,
                statusDelivery = dto.StatusDelivery,
                ProjectId = dto.ProjectId
            };
            await _repository.AddDelivery(delivery);
        }


        public async Task EditDelivery(int id, AddDeliveryDto dto)
        {
            var delivery = new Delivery
            {
                deliveryDate = dto.DeliveryDate,
                statusDelivery = dto.StatusDelivery,
                ProjectId = dto.ProjectId
            };

            await _repository.EditDelivery(id, delivery);
        }

        public async Task<IEnumerable<Delivery>> GetAllDeliveries()
        {
            var deliveries = await _repository.GetAllDeliveries();
            return deliveries;
        }

        public async Task<IEnumerable<Delivery>> GetAllDeliverys()
        {
            return await _repository.GetAllDeliveries();
        }

        public async Task<GetDeliveryDto> GetByIdDelivery(int id)
        {
            var delivery = await _repository.GetByIdDelivery(id);
            return new GetDeliveryDto
            {
                Id = delivery.Id,
                DeliveryDate = delivery.deliveryDate,
                StatusDelivery = delivery.statusDelivery,
                ProjectId = delivery.ProjectId
            };
        }

        public async Task RemoveDelivery(int id)
        {
            await _repository.RemoveDelivery(id);
        }
    }
}