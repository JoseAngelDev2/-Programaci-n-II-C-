using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Caspentry_Workshop.Application.DTOs.Delivery;
using Caspentry_Workshop.Application.DTOs.DeliveryDTOs;
using Caspentry_Workshop.Domain.Entities;

namespace Caspentry_Workshop.Application.Interfaces.Service
{
    public interface IDeliveryService
    {
        public Task AddDelivery(AddDeliveryDto delivery);
        public Task EditDelivery(int id, AddDeliveryDto delivery);
        public Task<GetDeliveryDto> GetByIdDelivery(int id);
        public Task<IEnumerable<Delivery>> GetAllDeliverys();
        public Task RemoveDelivery(int id);
    }
}