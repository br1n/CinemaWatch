using AutoMapper;
using CinemaWatch.Dtos;
using CinemaWatch.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using CinemaWatch.ViewModels;
using System.Web.Helpers;
using System.Web.WebPages;
using System.Security.Cryptography;
using System.Web;

namespace CinemaWatch.Controllers.API
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;
        
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<MovieDto> GetMovies(string query = null)
        {
            var moviesQuery = _context.Movies
                .Include(m => m.Genre)
                .Where(m => m.NumberAvailable > 0);

            if (!String.IsNullOrWhiteSpace(query))
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));

            return moviesQuery
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);
        }

        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        [HttpGet]
        [Route("api/Movies/MoviesByGenre")]
        public IHttpActionResult MoviesByGenre()
        {
            var moviesByGenre = _context.Movies
                .Include(m => m.Genre)
                .GroupBy(m => m.Genre.Name, m => m).Select(x => new GraphDataViewModel
                {
                    Name = x.Key,
                    Count = x.Count()
                }).ToList();

            

            return Json(moviesByGenre);
        }

        [HttpGet]
        [Route("api/Movies/MoviesByYear")]
        public IHttpActionResult MovieGenreByYear()
        {
            var movies = _context.Movies
                .GroupBy(x => x.ReleaseDate.Year, x=> x).Select(x => new GraphDataViewModel
                {
                    ReleaseDate = x.Key,
                    Count = x.Count()
                }).ToList();

            return Json(movies);
        }

        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movieInDb == null)
            {
                return NotFound();
            }

            Mapper.Map(movieDto, movieInDb);

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movieInDb == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
