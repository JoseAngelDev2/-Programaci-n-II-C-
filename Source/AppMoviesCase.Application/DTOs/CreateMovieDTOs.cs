using System;
using System.ComponentModel.DataAnnotations;
using AppMovieCase.Domain.Core;
using AppMoviesCase.Domain.Entities;

namespace AppMoviesCase.Application.DTOs;


public class CreateMovieDTO
{
    public string Title { get; set; }
    public string Overview { get; set; }
    public int Views { get; set; }
    public decimal Popularity { get; set; }
    public decimal VoteCount { get; set; }
    [Required]
    public ICollection<int> GenreIds { get; set; }
}

