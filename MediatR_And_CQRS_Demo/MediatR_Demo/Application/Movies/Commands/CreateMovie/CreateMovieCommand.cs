//Our command file will get the title, description, genre, and rating.
//These values will be returned to our CreateMovieDto which holds the Id of our created movie
using MediatR;
using MediatR_Demo.Core.Enums;
using MediatR_Demo.Domain.DTOs.Responses.Movie;

namespace MediatR_Demo.Application.Movies.Commands.CreateMovie
{
    public class CreateMovieCommand : IRequest<CreateMovieDto>
    {
        public CreateMovieCommand(string title, string description, MovieGenre genre, int? rating)
        {
            Title = title;
            Description = description;
            Rating = rating;
            Genre = genre;
        }

        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? Rating { get; set; }
        public MovieGenre Genre { get; set; }
    }
}
