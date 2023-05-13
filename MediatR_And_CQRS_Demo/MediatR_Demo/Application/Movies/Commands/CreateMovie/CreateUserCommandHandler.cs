using MediatR_Demo.Domain.DTOs.Responses.Movie;
using MediatR_Demo.Repository.Context;

namespace MediatR_Demo.Application.Movies.Commands.CreateMovie
{
    public class CreateUserCommandHandler
    {
        private ApplicationDbContext dbContext;

        public CreateUserCommandHandler(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<CreateMovieDto> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = request.CreateMovie();
            await this.dbContext.Movies.AddAsync(movie);
            await this.dbContext.SaveChangesAsync();
            return new CreateMovieDto(movie.Id);
        }
    }
}
