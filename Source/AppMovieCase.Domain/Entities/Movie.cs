using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppMovieCase.Domain.Core;

namespace AppMoviesCase.Domain.Entities
{
    public class Movie : BaseEntity
    {
        public string? Title { get; set; }
        public string? Overview { get; set; }
        public int Views { get; set; }
        public decimal Popularity { get; set; }
        public decimal VoteCount { get; set; }
        public ICollection<Genre>? MovieGenres { get; set; } = new List<Genre>();

    }
}