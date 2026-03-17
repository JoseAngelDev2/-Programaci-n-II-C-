using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using AppMovieCase.Domain.Core;

namespace AppMoviesCase.Domain.Entities
{
    public class Genre : BaseEntity
    {
        
        public DateTime created_at { get; set; } = DateTime.Now;
        public DateTime updated_at { get; set; } = DateTime.Now;
        public ICollection<Movie>? Movies { get; set; }

    }
}