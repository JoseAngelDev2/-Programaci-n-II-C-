using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AppMoviesCase.Application.Interfaces.Service;
using AppMoviesCase.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AppMoviesCase.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : Controller
    {
        private readonly IGenreService _repo;

        public GenreController(IGenreService repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllGenre()
        {
            var genres = await _repo.GetAllGenres();
            return Ok(genres);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult> GetGenre(int id)
        {
            var genre = await _repo.GetGenreById(id);
            return Ok(genre);
        }

        [HttpPost]

        public async Task<ActionResult> CreateGenre(Genre genre)
        {
            await _repo.AddGenre(genre);
            return NoContent();
        }

        [HttpPut]

        public async Task<ActionResult> UpdateGenre(Genre genre, int id)
        {
            await _repo.EditGenre(genre, id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGenre(int id)
        {
            await _repo.RemoveGenre(id);
            return NoContent();
        }

    }
}