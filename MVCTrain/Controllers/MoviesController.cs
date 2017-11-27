using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Security.Permissions;
using System.Text;
using System.Web;
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

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(x => x.Genre).FirstOrDefault(x => x.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(movie);
            }
        }
    }
}

