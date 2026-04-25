using Caspentry_Workshop.Application.DTOs.Project;
using Caspentry_Workshop.Application.DTOs.ProjectDTOs;
using Caspentry_Workshop.Application.Interfaces.Repository;
using Caspentry_Workshop.Application.Interfaces.Service;
using Caspentry_Workshop.Domain.Entities;

namespace Caspentry_Workshop.Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _repository;

        public ProjectService(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task AddProject(AddProjectDto dto)
        {
            var project = new Project
            {
                NameProyect = dto.NameProyect,
                Description = dto.Description,
                Status = dto.Status,
                Total = dto.Total,
                ClienteId = dto.ClienteId
            };
            await _repository.AddProject(project);
        }

        public async Task EditProject(int id, AddProjectDto dto)
        {
            var project = new Project
            {
                NameProyect = dto.NameProyect,
                Description = dto.Description,
                Status = dto.Status,
                Total = dto.Total,
                ClienteId = dto.ClienteId
            };
            await _repository.EditProject(id, project);
        }

        public async Task<IEnumerable<Project>> GetAllProjects()
        {
            var projects = await _repository.GetAllProjects();
            return projects;
        }

        public async Task<GetProjectDto> GetByIdProject(int id)
        {
            var project = await _repository.GetByIdProject(id);
            return new GetProjectDto
            {

                Id = project.Id,
                NameProyect = project.NameProyect,
                Description = project.Description,
                Status = project.Status,
                Total = project.Total,
                ClienteId = project.ClienteId
            };
        }

        public async Task RemoveProject(int id)
        {
            await _repository.RemoveProject(id);
        }
    }
}