using Caspentry_Workshop.Application.DTOs.CarpinterDTOs;
using Caspentry_Workshop.Application.DTOs.ClientDTOs;
using Caspentry_Workshop.Application.Interfaces.Repository;
using Caspentry_Workshop.Application.Interfaces.Service;
using Caspentry_Workshop.Domain.Entities;

namespace Caspentry_Workshop.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _repository;

        public ClientService(IClientRepository repository)
        {
            _repository = repository;
        }

        public async Task AddClient(AddClientDto dto)
        {
            var client = new Client
            {
                Name = dto.Name,
                Lastname = dto.Lastname,
                Address = dto.Address,
                Phone = dto.Phone,
                Email = dto.Email
            };
            await _repository.AddClient(client);
        }

        public async Task EditClient(int id, AddClientDto dto)
        {
            var client = new Client
            {
                Name = dto.Name,
                Lastname = dto.Lastname,
                Address = dto.Address,
                Phone = dto.Phone,
                Email = dto.Email
            };

            await _repository.EditClient(id, client);
        }

   

        public async Task<IEnumerable<Client>> GetAllClients()
        {
            var clients = await _repository.GetAllClients();
            return clients;
        }

        public async Task<GetClientDto> GetByIdClient(int id)
        {
            var client = await _repository.GetByIdClient(id);

            return new GetClientDto
            {
                Id = client.Id,
                Name = client.Name,
                Lastname = client.Lastname,
                Email = client.Email,
                Address = client.Address,
                Phone = client.Phone
            };
        }

        public async Task RemoveClient(int id)
        {
            await _repository.RemoveClient(id);
        }
    }
}