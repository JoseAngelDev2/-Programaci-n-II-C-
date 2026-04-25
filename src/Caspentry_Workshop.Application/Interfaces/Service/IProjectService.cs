using System;
using System.Collections.Generic;
using System.Linq;
using Caspentry_Workshop.Application.DTOs.Project;
using Caspentry_Workshop.Application.DTOs.ProjectDTOs;
using Caspentry_Workshop.Domain.Entities;

namespace Caspentry_Workshop.Application.Interfaces.Service
{
    public interface IProjectService
    {
        public Task AddProject(AddProjectDto project);
        public Task EditProject(int id, AddProjectDto project);
        public Task<GetProjectDto> GetByIdProject(int id);
        public Task<IEnumerable<Project>> GetAllProjects();
        public Task RemoveProject(int id);
    }
}