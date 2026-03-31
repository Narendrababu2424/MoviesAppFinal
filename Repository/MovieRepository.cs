using MoviesAppFinal.Data;
using MoviesAppFinal.Models;

namespace MoviesAppFinal.Repository
{
    public class MovieRepository : IRepository
    {
        private readonly MoviesDbContext _context;

        public MovieRepository(MoviesDbContext context)
        {
            _context = context;
        }

        public List<Movie> GetAll()
        {
            return _context.Movies.ToList();
        }

        public Movie? GetById(int id)
        {
            return _context.Movies.Find(id);
        }

        public void Add(Movie movie)
        {
            _context.Movies.Add(movie);
        }

        public void Update(Movie movie)
        {
            _context.Movies.Update(movie);
        }

        public void Delete(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}