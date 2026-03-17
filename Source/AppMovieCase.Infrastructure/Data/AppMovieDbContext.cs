using System;
using AppMovieCase.Infrastructure.Entities;
using AppMoviesCase.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppMovieCase.Infrastructure.Data;

public class AppMovieDbContext : DbContext
{
    public AppMovieDbContext(DbContextOptions<AppMovieDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<MovieModel>().Property(x => x.Popularity).HasColumnType("decimal(18,2)");
        modelBuilder.Entity<MovieModel>().Property(x => x.VoteCount).HasColumnType("decimal(18,2)");


        modelBuilder.Entity<MovieModel>().Property(x => x.VoteCount).HasColumnType("decimal(18,2)");
    }

    public DbSet<MovieModel> Movies { get; set; }
    public DbSet<GenreModel> Genres { get; set; }
    public DbSet<CategoryModel> Categories { get; set; }
    public DbSet<MovieGenreModel> MovieGenres { get; set; }
    public DbSet<MovieCategoryModel> movieCategories { get; set; }
}
