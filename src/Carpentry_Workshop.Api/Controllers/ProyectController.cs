using Caspentry_Workshop.Application.DTOs.Project;
using Caspentry_Workshop.Application.DTOs.ProjectDTOs;
using Caspentry_Workshop.Application.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace Carpentry_Workshop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _service;

        public ProjectController(IProjectService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetProjectDto>>> GetAllProjects()
        {
            var projects = await _service.GetAllProjects();
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetProjectDto>> GetByIdProject(int id)
        {
            var project = await _service.GetByIdProject(id);
            return Ok(project);
        }

        [HttpPost]
        public async Task<ActionResult> AddProject(AddProjectDto dto)
        {
            if (dto is null) return NotFound();
            await _service.AddProject(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProject(int id, AddProjectDto dto)
        {
            await _service.EditProject(id, dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveProject(int id)
        {
            await _service.RemoveProject(id);
            return Ok();
        }
    }
}