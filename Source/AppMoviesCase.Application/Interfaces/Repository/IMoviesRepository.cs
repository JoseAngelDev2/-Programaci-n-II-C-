using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppMoviesCase.Application.DTOs;
using AppMoviesCase.Domain.Entities;

namespace AppMovieCase.Application.Interfaces
{
    public interface IMoviesRepository
    {
        public Task<IEnumerable<Movie>> GetAllMovies();
        public Task<Movie> GetMovieById(int id);
        public Task AddMovie(Movie movie, List<int> genreIds);
        public Task EditMovie(Movie movie, int id);
        public Task RemoveMovie(int id);
    }
}