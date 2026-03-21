using AppMovieCase.Application.Interfaces;
using AppMovieCase.Application.Services;
using AppMoviesCase.Application.Interfaces.Service;
using AppMoviesCase.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace AppMoviesCase.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _repo;

        public CategoryController(ICategoryService repo)
        {
            _repo = repo;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategoryById(int id)
        {
            var category = await _repo.GetCategoryById(id);
            return Ok(category);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllContegories()
        {
            var categories = await _repo.GetAllCategories();
            return Ok(categories);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCategory(Category category)
        {
            await _repo.AddCategory(category);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCategory(Category category, int id)
        {
            await _repo.EditCategory(category, id);
            return NoContent();
        }

        [HttpDelete]

        public async Task<ActionResult> RemoveCategory(int id)
        {
            await _repo.RemoveCategory(id);
            return NoContent();
        }

    }
}
