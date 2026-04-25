using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Caspentry_Workshop.Application.DTOs.CarpinterDTOs;
using Caspentry_Workshop.Application.DTOs.ClientDTOs;
using Caspentry_Workshop.Application.Interfaces.Repository;
using Caspentry_Workshop.Domain.Entities;
using Caspentry_Workshop.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Caspentry_Workshop.Infraestructure.Repositories
{
    public class ClientRepository : IClientRepository
    {

        private readonly DbContextCapentryWorkshop _db;

        public ClientRepository(DbContextCapentryWorkshop db)
        {
            _db = db;
        }
        public async Task AddClient(Client client)
        {
            var NewClient = new ClientModel
            {
                Name = client.Name,
                Lastname = client.Lastname,
                Address = client.Address,
                Phone = client.Phone,

                Email = client.Email
            };

            await _db.Clients.AddAsync(NewClient);

            await SAVE();

        }


        public async Task EditClient(int id, Client client)
        {
            var foundClient = await _db.Clients.FindAsync(id);

            if (foundClient is null)
                throw new Exception($"Client with id {id} not found");

            foundClient.Name = client.Name;
            foundClient.Lastname = client.Lastname;
            foundClient.Address = client.Address;
            foundClient.Phone = client.Phone;
            foundClient.Email = client.Email;

            await SAVE();
        }

        public async Task<IEnumerable<Client>> GetAllClients()
        {
            var clients = await _db.Clients.AsNoTracking().ToListAsync();


            return clients.Select(x => new Client
            {
                Id = x.Id,
                Name = x.Name,
                Lastname = x.Lastname,
                Email = x.Email,
                Address = x.Address,
                Phone = x.Phone,
                Proyects = x.Proyects

            }).ToList();

        }

        public async Task<Client> GetByIdClient(int id)
        {
            var foundClient = await _db.Clients.FindAsync(id);

            if (foundClient is null)
                throw new Exception($"Client with id {id} not found");

            var client = new Client
            {
                Id = foundClient.Id,
                Name = foundClient!.Name,
                Lastname = foundClient.Lastname,
                Address = foundClient.Address,
                Phone = foundClient.Phone,
                Email = foundClient.Email
            };

            return client;
        }

        public async Task RemoveClient(int id)
        {
            var foundClient = await _db.Clients.FindAsync(id);

            if (foundClient is null)
            {
                Console.WriteLine("The client has been not found");
                return;
            }

            _db.Clients.Remove(foundClient);

            await SAVE();
        }

        public async Task SAVE()
        {
            await _db.SaveChangesAsync();
        }
    }
}