using CinemaWatch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CinemaWatch.ViewModels;
using System.Collections;

namespace CinemaWatch.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            var movies = GetMovies();


            return View(movies);
        }

        private IEnumerable GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Id = 1, Name = "The Thing"},
                new Movie { Id = 2, Name = "Animal House"}
            };
        }

        //GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "The Thing" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Elton" },
                new Customer { Name = "John"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        [Route("movies/released/{year:regex(\\d{2})}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }



        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }
    }
}