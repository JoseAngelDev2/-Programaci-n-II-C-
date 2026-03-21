using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Internal;
using AppMovieCase.Infrastructure.Data;

namespace AppMovieCase.Infrastructure.Data
{
    public class AppMovieCaseContextFactory : IDesignTimeDbContextFactory<AppMovieDbContext>
    {
        public AppMovieDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppMovieDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=AppMovieCaseDb;Trusted_Connection=True;TrustServerCertificate=True");

            return new AppMovieDbContext(optionsBuilder.Options);
        }
    }
}