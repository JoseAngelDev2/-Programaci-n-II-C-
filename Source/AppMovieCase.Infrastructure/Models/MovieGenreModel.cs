using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppMovieCase.Domain.Core;
using AppMoviesCase.Infrastructure.Entities;

namespace AppMovieCase.Infrastructure.Entities
{
    public class MovieGenreModel : BaseEntity
    {
        public int GenreId { get; set; }
        public GenreModel? Genre { get; set; }

        public int MovieId { get; set; }
        public MovieModel? Movie { get; set; }
    }
}