using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using AppMovieCase.Infrastructure.Entities;
using AppMoviesCase.Infrastructure.Entities;


namespace AppMoviesCase.Api.DTOs;

public class MovieDTOs
{
    [Required]
    [Length(3, 25)]
    public string? Title { get; set; }
    [Length(10, 150)]
    [Required]
    public string? Overview { get; set; }

    [Required]
    public int Views { get; set; }

    [Required]
    public decimal Popularity { get; set; }
        
    public decimal VoteCount { get; set; }
    public ICollection<GenreModel>? MovieGenres { get; set; } = new List<GenreModel>();
}
