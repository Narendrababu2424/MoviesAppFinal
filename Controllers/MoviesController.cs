using Microsoft.AspNetCore.Mvc;
using MoviesAppFinal.Dtos;
using MoviesAppFinal.Models;
using MoviesAppFinal.Repository;

namespace MoviesAppFinal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IRepository _repository;

        public MoviesController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<object> GetAllMovies(int pageNumber = 1, int pageSize = 5)
        {
            var allMovies = _repository.GetAll();

            var totalRecords = allMovies.Count;
            var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            var movies = allMovies
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(m => new MovieReadDto
                {
                    Id = m.Id,
                    Title = m.Title,
                    ReleaseYear = m.ReleaseYear,
                    Genre = m.Genre,
                    ImgUrl = m.ImgUrl
                })
                .ToList();

            var result = new
            {
                pageNumber,
                pageSize,
                totalRecords,
                totalPages,
                data = movies
            };

            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<MovieReadDto> GetMovieById(int id)
        {
            var movie = _repository.GetById(id);

            if (movie == null)
            {
                return NotFound();
            }

            var movieDto = new MovieReadDto
            {
                Id = movie.Id,
                Title = movie.Title,
                ReleaseYear = movie.ReleaseYear,
                Genre = movie.Genre,
                ImgUrl = movie.ImgUrl
            };

            return Ok(movieDto);
        }

        [HttpPost]
        public ActionResult<MovieReadDto> CreateMovie(MovieCreateDto movieCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var movie = new Movie
            {
                Title = movieCreateDto.Title,
                ReleaseYear = movieCreateDto.ReleaseYear,
                Genre = movieCreateDto.Genre,
                ImgUrl = movieCreateDto.ImgUrl
            };

            _repository.Add(movie);
            _repository.Save();

            var movieReadDto = new MovieReadDto
            {
                Id = movie.Id,
                Title = movie.Title,
                ReleaseYear = movie.ReleaseYear,
                Genre = movie.Genre,
                ImgUrl = movie.ImgUrl
            };

            return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id }, movieReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateMovie(int id, MovieUpdateDto movieUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingMovie = _repository.GetById(id);

            if (existingMovie == null)
            {
                return NotFound();
            }

            existingMovie.Title = movieUpdateDto.Title;
            existingMovie.ReleaseYear = movieUpdateDto.ReleaseYear;
            existingMovie.Genre = movieUpdateDto.Genre;
            existingMovie.ImgUrl = movieUpdateDto.ImgUrl;

            _repository.Update(existingMovie);
            _repository.Save();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMovie(int id)
        {
            var existingMovie = _repository.GetById(id);

            if (existingMovie == null)
            {
                return NotFound();
            }

            _repository.Delete(id);
            _repository.Save();

            return NoContent();
        }
    }
}