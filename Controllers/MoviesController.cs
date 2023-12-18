using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoRentalProject.Models;

namespace VideoRentalProject.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            List<Movie> Movies = new List<Movie>()
            {
                new Movie() {id = 1, Name = "Wall-E"},
                new Movie() {id = 2, Name = "Aminal"}
            };

            return View(Movies);

        }
    }
}