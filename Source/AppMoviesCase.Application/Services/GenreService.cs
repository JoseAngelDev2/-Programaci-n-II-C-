using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppMovieCase.Application.Interfaces;
using AppMoviesCase.Application.Interfaces.Service;
using AppMoviesCase.Domain.Entities;

namespace AppMoviesCase.Application.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _repo;

        public GenreService(IGenreRepository repo)
        {
            _repo = repo;
        }
        public async Task AddGenre(Genre genre)
        {
            await _repo.AddGenre(genre);
        }

        public async Task EditGenre(Genre genre, int id)
        {
            await _repo.EditGenre(genre, id);
        }

        public async Task<IEnumerable<Genre>> GetAllGenres()
        {
            var genres = await _repo.GetAllGenres();
            return genres;
        }

        public async Task<Genre> GetGenreById(int id)
        {
            var genre = await _repo.GetGenreById(id);
            return genre;
        }

        public async Task RemoveGenre(int id)
        {
            await _repo.RemoveGenre(id);
        }
    }
}