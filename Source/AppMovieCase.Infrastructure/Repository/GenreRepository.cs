using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppMovieCase.Application.Interfaces;
using AppMoviesCase.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using AppContext = AppMovieCase.Infrastructure.Data.AppMovieDbContext;
namespace AppMovieCase.Infrastructure.Repository
{
    public class GenreRepository : IGenreRepository
    {

        private readonly AppContext _app;

        public GenreRepository(AppContext app)
        {
            _app = app;
        }

        public Task AddGenre(Genre genre)
        {
            throw new NotImplementedException();
        }

        public Task EditGenre(Genre genre, int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Genre>> GetAllGenres()
        {
            var genres = await _app.Genres.AsNoTracking().ToListAsync();


            return genres.Select(g => new Genre
            {
                Name = g.Name,
                created_at = g.created_at,
                updated_at = g.updated_at
            });
        }

        public async Task<Genre> GetGenreById(int id)
        {
            var genre = await _app.Genres.FindAsync(id);

            if (genre is null) { return null!; }

            var genreModel = new Genre
            {
                Id = genre.Id,
                Name = genre.Name,
                created_at = genre.created_at,
                updated_at = genre.updated_at
            };

            return genreModel;
        }

        public Task RemoveGenre(int id)
        {
            throw new NotImplementedException();
        }
    }
}