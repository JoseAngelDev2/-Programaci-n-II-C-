using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using AppMovieCase.Domain.Core;

namespace AppMoviesCase.Infrastructure.Entities
{
    public class GenreModel : BaseEntity
    {
        public DateTime created_at { get; set; } = DateTime.Now;
        public DateTime updated_at { get; set; } = DateTime.Now;

        public ICollection<MovieModel> Movies { get; set; } = new List<MovieModel>();
    }
}