using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppMovieCase.Domain.Entities;
using AppMoviesCase.Application.DTOs;
using AppMoviesCase.Domain.Entities;
namespace AppMoviesCase.Application.Interfaces.Service
{
    public interface IMovieService
    {

        public Task<IEnumerable<Movie>> GetAllMovies();
        public Task<Movie> GetMovieById(int id);
        public Task AddMovie(CreateMovieDTO movie, List<int> genreIds);
        public Task EditMovie(Movie movie, int id);
        public Task RemoveMovie(int id);
    }
}