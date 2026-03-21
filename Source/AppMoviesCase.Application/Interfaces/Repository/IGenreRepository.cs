using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppMoviesCase.Domain.Entities;

namespace AppMovieCase.Application.Interfaces
{
    public interface IGenreRepository
    {
        public Task<IEnumerable<Genre>> GetAllGenres();
        public Task<Genre> GetGenreById(int id);
        public Task AddGenre(Genre genre);
        public Task EditGenre(Genre genre, int id);
        public Task RemoveGenre(int id);
    }
}