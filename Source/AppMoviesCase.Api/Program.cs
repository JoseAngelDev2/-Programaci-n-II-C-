using AppMovieCase.Application.Interfaces;
using AppMovieCase.Application.Services.MovieService;
using AppMovieCase.Infrastructure.Repository;
using AppMoviesCase.Application.Interfaces.Service;
using AppMoviesCase.Application.Services;
using AppMoviesCase.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using AppDbContext = AppMovieCase.Infrastructure.Data.AppMovieDbContext;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IMoviesRepository, MoviesRepository>();
builder.Services.AddScoped<IMovieService, MoviesService>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<IGenreService, GenreService>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();