using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AppMovieCase.Domain.Core;
using AppMoviesCase.Infrastructure.Entities;

namespace AppMovieCase.Infrastructure.Entities
{
    public class MovieCategoryModel : BaseEntity
    {
        public int MovieId { get; set; }
        public MovieModel? Movie { get; set; }

        public int CategoryId {get; set;}
        public CategoryModel? Category {get; set;}

    }
}