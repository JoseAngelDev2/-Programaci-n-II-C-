using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using AppMovieCase.Domain.Entities;
using AppMoviesCase.Domain.Entities;


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
    public ICollection<Genre>? MovieGenres { get; set; } = new List<Genre>();
}
