using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppMovieCase.Domain.Core;
using AppMoviesCase.Domain.Entities;

namespace AppMovieCase.Domain.Entities
{
    public class MovieGenre : BaseEntity
    {
        public int GenreId { get; set; }
        public Genre? Genre { get; set; }

        public int MovieId { get; set; }
        public Movie? Movie { get; set; }
    }
}