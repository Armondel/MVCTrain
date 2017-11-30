using System;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;
using MVCTrain.Models;
using MVCTrain.ViewModels;

namespace MVCTrain.App_Start
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var movies = _context.Movies.Include(x => x.Genre);

            return View(movies);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Include(x => x.Genre).FirstOrDefault(x => x.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            var movieViewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };
            return View("MovieView", movieViewModel);
        }

        public ActionResult New()
        {
            var movieViewModel = new MovieFormViewModel
            {
                Genres = _context.Genres.ToList()
            };

            return View("MovieView", movieViewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.First(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
    }
}

