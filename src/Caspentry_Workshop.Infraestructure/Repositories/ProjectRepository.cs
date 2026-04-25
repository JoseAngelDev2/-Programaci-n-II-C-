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
    public class ProjectRepository : IProjectRepository
    {
        private readonly DbContextCapentryWorkshop _db;

        public ProjectRepository(DbContextCapentryWorkshop db)
        {
            _db = db;
        }

        public async Task AddProject(Project project)
        {
            var newProject = new ProjectModel
            {
                NameProyect = project.NameProyect,
                Description = project.Description,
                Status = project.Status,
                Total = project.Total,
                ClienteId = project.ClienteId
            };

            await _db.Projects.AddAsync(newProject);
            await SAVE();
        }

        public async Task EditProject(int id, Project project)
        {
            var foundProject = await _db.Projects.FindAsync(id);

            if (foundProject is null)
                throw new Exception($"Project with id {id} not found");

            foundProject.NameProyect = project.NameProyect;
            foundProject.Description = project.Description;
            foundProject.Status = project.Status;
            foundProject.Total = project.Total;
            foundProject.ClienteId = project.ClienteId;

            await SAVE();
        }

        public async Task<IEnumerable<Project>> GetAllProjects()
        {
            var projects = await _db.Projects.AsNoTracking().ToListAsync();

            return projects.Select(x => new Project
            {
                Id = x.Id,
                NameProyect = x.NameProyect,
                Description = x.Description,
                Status = x.Status,
                Total = x.Total,
                ClienteId = x.ClienteId

            }).ToList();
        }

        public async Task<Project> GetByIdProject(int id)
        {
            var foundProject = await _db.Projects.FindAsync(id);

            if (foundProject is null)
            {
                throw new Exception($"Project with id {id} not found");
            }

            var project = new Project
            {
                Id = foundProject.Id,
                NameProyect = foundProject.NameProyect,
                Description = foundProject.Description,
                Status = foundProject.Status,
                Total = foundProject.Total,
                ClienteId = foundProject.ClienteId
            };

            return project;
        }

        public async Task RemoveProject(int id)
        {
            var foundProject = await _db.Projects.FindAsync(id);

            if (foundProject is null)
            {
                Console.WriteLine("The project has not been found");
                return;
            }

            _db.Projects.Remove(foundProject);
            await SAVE();
        }

        public async Task SAVE()
        {
            await _db.SaveChangesAsync();
        }
    }
}