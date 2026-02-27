// Student Name: Muni Narendra
// Student ID: 9050878

using Microsoft.AspNetCore.Mvc;
using MoviesAppFinal.Models;
using MoviesAppFinal.Repository;

namespace MoviesAppFinal.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IRepository _repository;

        public MoviesController(IRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var movies = _repository.GetAll();
            return View(movies);
        }

        public IActionResult Details(int id)
        {
            var movie = _repository.GetById(id);
            if (movie == null)
                return NotFound();

            return View(movie);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(movie);
                _repository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        public IActionResult Edit(int id)
        {
            var movie = _repository.GetById(id);
            if (movie == null)
                return NotFound();

            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(movie);
                _repository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        public IActionResult Delete(int id)
        {
            var movie = _repository.GetById(id);
            if (movie == null)
                return NotFound();

            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);
            _repository.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}