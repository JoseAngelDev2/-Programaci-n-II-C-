using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Caspentry_Workshop.Application.Interfaces.Repository;
using Caspentry_Workshop.Domain.Entities;
using Caspentry_Workshop.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Caspentry_Workshop.Infraestructure.Repositories
{
    public class DeliveryRepository : IDeliveryRepository
    {
        private readonly DbContextCapentryWorkshop _db;

        public DeliveryRepository(DbContextCapentryWorkshop db)
        {
            _db = db;
        }

        public async Task AddDelivery(Delivery delivery)
        {
            var project = await _db.Projects.AnyAsync(x => x.Id == delivery.ProjectId);

            if (!project)
            {
                throw new Exception("The ProyectId has been not found");
            }
            var newDelivery = new DeliveryModel
            {
                deliveryDate = DateTime.SpecifyKind(delivery.deliveryDate, DateTimeKind.Utc),
                statusDelivery = delivery.statusDelivery,
                ProjectId = delivery.ProjectId
            };

            await _db.Deliveries.AddAsync(newDelivery);
            await SAVE();
        }

        public async Task EditDelivery(int id, Delivery delivery)
        {
            var foundDelivery = await _db.Deliveries.FindAsync(id);

            if (foundDelivery is null)
                throw new Exception($"Delivery with id {id} not found");

            var project = await _db.Projects.AnyAsync(x => x.Id == delivery.Id);

            if (project =! true)
                throw new Exception($"Project with id {delivery.ProjectId} not found");

            foundDelivery.deliveryDate = delivery.deliveryDate;
            foundDelivery.statusDelivery = delivery.statusDelivery;
            foundDelivery.ProjectId = delivery.ProjectId;

            await SAVE();
        }

        public async Task<IEnumerable<Delivery>> GetAllDeliveries()
        {
            var deliveries = await _db.Deliveries
                .AsNoTracking()
                .Include(x => x.Project)
                .ToListAsync();

            return deliveries.Select(x => new Delivery
            {
                Id = x.Id,
                deliveryDate = x.deliveryDate,
                statusDelivery = x.statusDelivery,
                ProjectId = x.ProjectId

            }).ToList();
        }

        public async Task<Delivery> GetByIdDelivery(int id)
        {
            var foundDelivery = await _db.Deliveries
                .Include(x => x.Project)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (foundDelivery is null)
                throw new Exception($"Delivery with id {id} not found");

            return new Delivery
            {
                Id = foundDelivery.Id,
                deliveryDate = foundDelivery.deliveryDate,
                statusDelivery = foundDelivery.statusDelivery,
                ProjectId = foundDelivery.ProjectId,
            };
        }

        public async Task RemoveDelivery(int id)
        {
            var foundDelivery = await _db.Deliveries.FindAsync(id);

            if (foundDelivery is null)
            {
                Console.WriteLine("The delivery has not been found");
                return;
            }

            _db.Deliveries.Remove(foundDelivery);
            await SAVE();
        }

        public async Task SAVE()
        {
            await _db.SaveChangesAsync();
        }
    }
}