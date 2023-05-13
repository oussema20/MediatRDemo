using MediatR_Demo.Domain.Movie;
using Microsoft.EntityFrameworkCore;

namespace MediatR_Demo.Repository.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
    }
}
