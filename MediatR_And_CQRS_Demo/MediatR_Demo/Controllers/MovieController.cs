using MediatR;
using MediatR_Demo.Application.Movies.Commands.CreateMovie;
using MediatR_Demo.Application.Movies.Queries.GetMovies;
using MediatR_Demo.Domain.DTOs.Requests.Movie;
using Microsoft.AspNetCore.Mvc;

namespace MediatR_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private IMediator mediator;

        public MovieController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateMovie([FromBody] CreateMovieRequest request)
        {
            var movie = await this.mediator.Send(new CreateMovieCommand(request.Title, request.Description, request.Genre, request.Rating));
            return Ok(movie);
        }

        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            var movies = await this.mediator.Send(new GetMoviesQuery());
            return Ok(movies);
        }

    }
}
