using Microsoft.EntityFrameworkCore;
using MoviesAppFinal.Models;

namespace MoviesAppFinal.Data
{
    public class MoviesDbContext : DbContext
    {
        public MoviesDbContext(DbContextOptions<MoviesDbContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
    }
}