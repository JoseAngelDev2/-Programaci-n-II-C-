using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppMovieCase.Domain.Entities;
using AppMovieCase.Domain.Interfaces;
using AppMoviesCase.Api.DTOs;
using AppMoviesCase.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AppMoviesCase.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesRepository _app;

        public MoviesController(IMoviesRepository app)
        {
            _app = app;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDTOs>>> GetAllMovies()
        {
            var movies = await _app.GetAllMovies();

            return Ok(movies.Select(x => new MovieDTOs
            {
               Title = x.Title,
               Overview = x.Overview,
               Views = x.Views,
               VoteCount = x.VoteCount,
               Popularity = x.Popularity
            }).ToList());

        } 

              
        [HttpGet("{id}")]
        public async Task<ActionResult> GetMovieById(int id)
        {
           var movie = await _app.GetMovieById(id);
           return Ok(movie);
        }

        [HttpPost]

        public async Task<ActionResult> AddMovie(Movie movie)
        {
            await _app.AddMovie(movie);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateMovie(Movie movie, int id)
        {
            await _app.EditMovie(movie, id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveMovie(int id)
        {
            await _app.RemoveMovie(id);
            return NoContent();
        }


    }
}