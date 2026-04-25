using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Caspentry_Workshop.Domain.Entities;

namespace Caspentry_Workshop.Application.Interfaces.Repository
{
    public interface IProjectRepository
    {
        public Task AddProject(Project project);
        public Task EditProject(int id, Project dto);
        public Task<Project> GetByIdProject(int id);
        public Task<IEnumerable<Project>> GetAllProjects();
        public Task RemoveProject(int id);
    }
}