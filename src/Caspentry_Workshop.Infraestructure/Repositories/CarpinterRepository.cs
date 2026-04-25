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
    public class CarpinterRepository : ICarpinterRepository
    {
        private readonly DbContextCapentryWorkshop _db;

        public CarpinterRepository(DbContextCapentryWorkshop db)
        {
            _db = db;
        }

        public async Task AddCarpinter(Carpinter carpinter)
        {
            var newCarpinter = new CarpinterModel
            {
                Name = carpinter.Name,
                Specialty = carpinter.Specialty,
                Phone = carpinter.Phone,
                Salary = carpinter.Salary
            };

            await _db.Carpinters.AddAsync(newCarpinter);
            await SAVE();
        }

        public async Task EditCarpinter(int id, Carpinter carpinter)
        {
            var foundCarpinter = await _db.Carpinters.FindAsync(id);

            if (foundCarpinter is null)
                throw new Exception($"Carpinter with id {id} not found");

            foundCarpinter.Name = carpinter.Name;
            foundCarpinter.Specialty = carpinter.Specialty;
            foundCarpinter.Phone = carpinter.Phone;
            foundCarpinter.Salary = carpinter.Salary;

            await SAVE();
        }


        public async Task<IEnumerable<Carpinter>> GetAllCarpinters()
        {
            var carpinters = await _db.Carpinters.AsNoTracking().ToListAsync();

            return carpinters.Select(x => new Carpinter
            {
                Id = x.Id,
                Name = x.Name,
                Specialty = x.Specialty,
                Phone = x.Phone,
                Salary = x.Salary

            }).ToList();
        }

        public async Task<Carpinter> GetByIdCarpinter(int id)
        {
            var foundCarpinter = await _db.Carpinters.FindAsync(id);

            if (foundCarpinter is null)
                throw new Exception($"Carpinter with id {id} not found");

            return new Carpinter
            {
                Name = foundCarpinter.Name,
                Specialty = foundCarpinter.Specialty,
                Phone = foundCarpinter.Phone,
                Salary = foundCarpinter.Salary
            };
        }

        public async Task EditDelivery(int id, Delivery delivery)
        {
            var foundDelivery = await _db.Deliveries.FindAsync(id);

            if (foundDelivery is null)
                throw new Exception($"Delivery with id {id} not found");

            var projectExists = await _db.Projects.AnyAsync(x => x.Id == delivery.ProjectId);

            if (!projectExists)
                throw new Exception($"Project with id {delivery.ProjectId} not found");

            foundDelivery.deliveryDate = delivery.deliveryDate;
            foundDelivery.statusDelivery = delivery.statusDelivery;
            foundDelivery.ProjectId = delivery.ProjectId;

            await SAVE();
        }

        public async Task RemoveCarpinter(int id)
        {
            var foundCarpinter = await _db.Carpinters.FindAsync(id);

            if (foundCarpinter is null)
            {
                Console.WriteLine("The carpinter has not been found");
                return;
            }

            _db.Carpinters.Remove(foundCarpinter);
            await SAVE();
        }

        public async Task SAVE()
        {
            await _db.SaveChangesAsync();
        }
    }
}