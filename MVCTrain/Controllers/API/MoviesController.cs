using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using AutoMapper;
using MVCTrain.DTO;
using MVCTrain.Models;
using MVCTrain.Models.Validation;

namespace MVCTrain.Controllers.API
{
    [ApiAuthorize]
    public class MoviesController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }


        // GET api/movies
        public IHttpActionResult GetMovies()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Json(new {message="Access Denied"});
            }

            var movieDtos = _context.Movies
                .Include(m => m.Genre)
                .ToList()
                .Select(Mapper.Map <Movie, MovieDto>);
            return Ok(movieDtos);
        }

        // GET api/movies/1
        public IHttpActionResult GetMovie(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Json(new { message = "Access Denied" });
            }

            var movie = _context.Movies.FirstOrDefault(c => c.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        // POST api/movies
        [HttpPost]
        [ApiAuthorize(Roles = "CanManageMovies")]
        public IHttpActionResult AddMovie(MovieDto movieDto)
        {
            if (!User.IsInRole("CanManageMovies"))
            {
                return Json(new { message = "Access Denied" });
            }

            if (!ModelState.IsValid)
                return BadRequest();
            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            movie.DateAdded = DateTime.Now;
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);

        }

        // PUT api/movies/1
        [HttpPut]
        [ApiAuthorize(Roles = "CanManageMovies")]
        public void UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movieInDb = _context.Movies.FirstOrDefault(m => m.Id == id);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(movieDto, movieInDb);

            _context.SaveChangesAsync();

        }

        // DELETE api/movies/1
        [HttpDelete]
        [ApiAuthorize(Roles = "CanManageMovies")]
        public void DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.FirstOrDefault(m => m.Id == id);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();

        }
    }
}
