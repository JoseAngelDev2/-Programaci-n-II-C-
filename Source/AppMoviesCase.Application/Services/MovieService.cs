using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AppMovieCase.Domain.Entities;
using AppMovieCase.Application.Interfaces;
using AppMoviesCase.Application.Interfaces.Service;
using AppMoviesCase.Domain.Entities;
using AppMoviesCase.Application.DTOs;
namespace AppMovieCase.Application.Services.MovieService
{
    public class MoviesService : IMovieService
    {
        private readonly IMoviesRepository _app;

        public MoviesService(IMoviesRepository app)
        {
            _app = app;
        }

        public async Task AddMovie(CreateMovieDTO movie, List<int> genreIds)
        {
            var MovieDTO = new Movie
            {
                Title = movie.Title,
                Overview = movie.Overview,
                Views = movie.Views,
                VoteCount = movie.VoteCount,
                Popularity = movie.Popularity
            };
            await _app.AddMovie(MovieDTO, genreIds);
        }


        public async Task EditMovie(Movie NewMovie, int id)
        {
            await _app.EditMovie(NewMovie, id);
        }
        public async Task<IEnumerable<Movie>> GetAllMovies()
        {
            var movies = await _app.GetAllMovies();
            return movies;

        }

        public async Task<Movie> GetMovieById(int id)
        {
            var movie = await _app.GetMovieById(id);
            return movie;
        }
        public async Task RemoveMovie(int id)
        {
            await _app.RemoveMovie(id);
        }
    }
}