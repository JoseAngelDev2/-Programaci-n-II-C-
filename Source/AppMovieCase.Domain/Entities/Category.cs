using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AppMovieCase.Domain.Core;

namespace AppMoviesCase.Domain.Entities
{
    public class Category : BaseEntity
    {
        public DateTime created_at { get; set; } = DateTime.Now;
        public DateTime update_at { get; set; } = DateTime.Now;
        public ICollection<Category>? Movies { get; set; }
    }
}