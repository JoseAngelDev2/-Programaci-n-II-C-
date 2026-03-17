using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppMoviesCase.Domain.Entities;

namespace AppMovieCase.Domain.Interfaces
{
    public interface IMoviesRepository
    {
        public Task<IEnumerable<Movie>> GetAllMovies();
        public Task<Movie> GetMovieById(int id);
        public Task AddMovie(Movie movie);
        public Task EditMovie(Movie movie, int id);
        public Task RemoveMovie(int id);
    }
}