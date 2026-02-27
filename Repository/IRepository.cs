using MoviesAppFinal.Models;

namespace MoviesAppFinal.Repository
{
    public interface IRepository 
    {
        List<Movie> GetAll();
        Movie? GetById(int id);
        void Add(Movie movie);
        void Update(Movie movie);
        void Delete(int id);
        void Save();
    }
}