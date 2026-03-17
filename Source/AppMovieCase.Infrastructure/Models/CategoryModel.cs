using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AppMovieCase.Domain.Core;

namespace AppMoviesCase.Infrastructure.Entities
{
    public class CategoryModel : BaseEntity
    {
        public DateTime created_at { get; set; } = DateTime.Now;
        public DateTime update_at { get; set; } = DateTime.Now;
        public ICollection<CategoryModel>? Movies { get; set; }
    }
}