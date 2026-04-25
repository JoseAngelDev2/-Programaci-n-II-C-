using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Caspentry_Workshop.Application.DTOs.CarpinterDTOs;
using Caspentry_Workshop.Application.DTOs.ClientDTOs;
using Caspentry_Workshop.Domain.Entities;

namespace Caspentry_Workshop.Application.Interfaces.Service
{
    public interface IClientService
    {
        public Task AddClient(AddClientDto client);
        public Task EditClient(int id, AddClientDto dto);
        public Task<GetClientDto> GetByIdClient(int id);
        public Task<IEnumerable<Client>> GetAllClients();
        public Task RemoveClient(int id);
    }
}