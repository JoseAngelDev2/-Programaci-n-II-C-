using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppMovieCase.Domain.Core;

namespace AppMoviesCase.Infrastructure.Entities
{
    public class MovieModel : BaseEntity
    {
        public string? Title { get; set; }
        public string? Overview { get; set; }
        public int Views { get; set; }
        public decimal Popularity { get; set; }
        public decimal VoteCount { get; set; }
        public ICollection<GenreModel>? MovieGenres { get; set; } = new List<GenreModel>();

    }
}