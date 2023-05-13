using MediatR;
using MediatR_Demo.Domain.DTOs.Responses.Movie;
using MediatR_Demo.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace MediatR_Demo.Application.Movies.Queries.GetMovies
{
    public class GetMoviesQueryHandler: IRequestHandler<GetMoviesQuery, IList<GetMovieDto>>
    {
        private ApplicationDbContext dbContext;

        public GetMoviesQueryHandler(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IList<GetMovieDto>> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
        {
            var movies = await this.dbContext.Movies.ToListAsync();
            var moviesList = new List<GetMovieDto>();
            foreach (var movieItem in movies)
            {
                var movie = movieItem.MapTo();
                moviesList.Add(movie);
            }
            return moviesList;
        }
    }
}
