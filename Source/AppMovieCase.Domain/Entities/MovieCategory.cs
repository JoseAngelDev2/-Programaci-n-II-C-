using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AppMovieCase.Domain.Core;
using AppMoviesCase.Domain.Entities;

namespace AppMovieCase.Domain.Entities
{
    public class MovieCategory : BaseEntity
    {
        public int MovieId { get; set; }
        public Movie? Movie { get; set; }

        public int CategoryId {get; set;}
        public Category? Category {get; set;}

    }
}