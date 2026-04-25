using Caspentry_Workshop.Application.DTOs.Carpinter;
using Caspentry_Workshop.Application.DTOs.CarpinterDTOs;
using Caspentry_Workshop.Application.Interfaces.Repository;
using Caspentry_Workshop.Application.Interfaces.Service;
using Caspentry_Workshop.Domain.Entities;

namespace Caspentry_Workshop.Application.Services
{
    public class CarpinterService : ICarpinterService
    {
        private readonly ICarpinterRepository _repository;

        public CarpinterService(ICarpinterRepository repository)
        {
            _repository = repository;
        }

        public async Task AddCarpinter(AddCarpinterDto dto)
        {
            var carpinter = new Carpinter
            {
                Name = dto.Name,
                Specialty = dto.Specialty,
                Phone = dto.Phone,
                Salary = dto.Salary
            };
            await _repository.AddCarpinter(carpinter);
        }

        public async Task EditCarpinter(int id, AddCarpinterDto dto)
        {
            var carpinter = new Carpinter
            {
                Name = dto.Name,
                Specialty = dto.Specialty,
                Phone = dto.Phone,
                Salary = dto.Salary
            };
            
            await _repository.EditCarpinter(id, carpinter);
        }

        public async Task<IEnumerable<Carpinter>> GetAllCarpinters()
        {
            var carpinters = await _repository.GetAllCarpinters();
            return carpinters;
        }

        public async Task<GetCarpinterDto> GetByIdCarpinter(int id)
        {
            var carpinter = await _repository.GetByIdCarpinter(id);
            return new GetCarpinterDto
            {
                Name = carpinter.Name,
                Specialty = carpinter.Specialty,
                Phone = carpinter.Phone,
                Salary = carpinter.Salary
            };
        }

        public async Task RemoveCanpinter(int id)
        {
            await _repository.RemoveCarpinter(id);
        }


    }
}