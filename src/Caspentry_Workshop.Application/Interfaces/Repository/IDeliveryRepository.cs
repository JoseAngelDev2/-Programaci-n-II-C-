using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Caspentry_Workshop.Domain.Entities;

namespace Caspentry_Workshop.Application.Interfaces.Repository
{
    public interface IDeliveryRepository
    {
        public Task AddDelivery(Delivery delivery);
        public Task EditDelivery(int id, Delivery dto);
        public Task<Delivery> GetByIdDelivery(int id);
        public Task<IEnumerable<Delivery>> GetAllDeliveries();
        public Task RemoveDelivery(int id);
    }
}