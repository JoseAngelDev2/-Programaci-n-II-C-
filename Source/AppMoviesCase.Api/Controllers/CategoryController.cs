using AppMovieCase.Domain.Interfaces;
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
        private readonly ICategoryRepository _repo;

        public CategoryController(ICategoryRepository repo)
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
            var categories = await _repo.GetAllCategory();
            return Ok(categories);
        }

        [HttpPost]

        public async Task<ActionResult> CreateCategory(Category category)
        {
            await _repo.AddCategory(category);
            return NoContent();
        }

    }
}
