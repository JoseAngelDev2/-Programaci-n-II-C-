using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Caspentry_Workshop.Domain.Entities;

namespace Caspentry_Workshop.Application.Interfaces.Repository
{
    public interface IClientRepository
    {
        public Task AddClient(Client client);
        public Task EditClient(int id, Client dto);
        public Task<Client> GetByIdClient(int id);
        public Task<IEnumerable<Client>> GetAllClients();
        public Task RemoveClient(int id);
    }
}