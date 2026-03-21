using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppMoviesCase.Domain.Entities;

namespace AppMoviesCase.Application.Interfaces.Service
{
    public interface IGenreService
    {
        public Task<IEnumerable<Genre>> GetAllGenres();
        public Task<Genre> GetGenreById(int id);
        public Task AddGenre(Genre genre);
        public Task EditGenre(Genre genre, int id);
        public Task RemoveGenre(int id);
    }
}