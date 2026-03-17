using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AppMovieCase.Domain.Interfaces;
using AppMovieCase.Infrastructure.Entities;
using AppMovieCase.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using AppDbContext = AppMovieCase.Infrastructure.Data.AppMovieDbContext;
using AppMoviesCase.Domain.Entities;
using AppMoviesCase.Infrastructure.Entities;
namespace AppMovieCase.Infrastructure.Repository
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly AppDbContext _app;

        public MoviesRepository(AppDbContext app)
        {
            _app = app;
        }

        public async Task AddMovie(Movie movie)
        {
            var NewMovie = new MovieModel
            {
                Title = movie.Title,
                Overview = movie.Overview,
                Views = movie.Views,
                Popularity = movie.Popularity,
                VoteCount = movie.VoteCount
            };

            await _app.Movies.AddAsync(NewMovie);
            await SAVE();
        }


        public async Task EditMovie(Movie NewMovie, int id)
        {
            var movie = await _app.Movies.Include(x => x.MovieGenres).Where(x => x.Id == id).FirstOrDefaultAsync();
            if (movie is null)
            {
                return;
            }
            movie.Name = NewMovie.Name == null ? movie.Name : NewMovie.Name;
            movie.Title = NewMovie.Title == null ? movie.Title : NewMovie.Title;
            movie.Overview = NewMovie.Overview == null ? movie.Overview : NewMovie.Overview;
            movie.Popularity = NewMovie.Popularity == 0 ? movie.Popularity : NewMovie.Popularity;
            movie.Views = NewMovie.Views == 0 ? movie.Views : NewMovie.Views;
            movie.VoteCount = NewMovie.VoteCount == 0 ? movie.VoteCount : movie.VoteCount;

            await SAVE();
        }



        public async Task<IEnumerable<Movie>> GetAllMovies()
        {
            var movies = await _app.Movies.Include(x => x.MovieGenres)
            .AsTracking().ToListAsync();

            return movies.Select(m => new Movie
            {
                Id = m.Id,
                Title = m.Title,
                Overview = m.Overview,
                Popularity = m.Popularity,
                VoteCount = m.VoteCount,
                Views = m.Views
            }).ToList();

        }

        public async Task<Movie> GetMovieById(int id)
        {
            var movie = await _app.Movies
            .Include(x => x.MovieGenres)
            .Where(x => x.Id == id)
             .FirstOrDefaultAsync();


            if (movie is null)
            {
                Console.WriteLine("Movie not found");
                return null!;
            }

            var movieModel = new Movie
            {
                Id = movie.Id,
                Title = movie.Title,
                Popularity = movie.Popularity,
                Overview = movie.Overview,
                VoteCount = movie.VoteCount,
                Views = movie.Views,
            };

            return movieModel;
        }


        public async Task RemoveMovie(int id)
        {
            var movie = await _app.Movies.FindAsync(id);

            if (movie is null)
            {
                return;
            }

            _app.Remove(movie);
            await SAVE();
        }


        public async Task SAVE()
        {
            await _app.SaveChangesAsync();
        }
    }
}