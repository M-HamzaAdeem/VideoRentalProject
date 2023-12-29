using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoRentalProject.Models;
using System.Data.Entity;
using VideoRentalProject.ViewModels;
using System.Xml.Linq;

namespace VideoRentalProject.Controllers
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
        // GET: Movies
        public ActionResult Index()
        {
            var Movies = _context.Movies.Include(m=>m.Genre).ToList();
            return View(Movies);

        }
        public ActionResult Details(int id)
        {
            var Movie = _context.Movies.Include(m => m.Genre).FirstOrDefault(m=>m.Id == id);
            return View(Movie);

        }

        public ActionResult New()
        {
            var Genre = _context.Genre.ToList();
            var viewModel = new MovieFormViewModel()
            {
                Genre = Genre,

        };

            return View("MovieForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.FirstOrDefault(c => c.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            var viewModel = new MovieFormViewModel(movie)
            {
                Genre = _context.Genre.ToList(),
                SelectedGenreIds = movie.Genre.Select(g => g.Id).ToArray()
            };
            

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(MovieFormViewModel viewModel)
        {
            if(!ModelState.IsValid)
            {
                viewModel.Genre = _context.Genre.ToList();
                
                return View("MovieForm", viewModel);
            }
            var movie = new Movie(viewModel);
            

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now; 
                _context.Movies.Add(movie);
                movie.Genre = new List<Genre>();
                if(viewModel.SelectedGenreIds !=null)
                { 
                    foreach (var genreId in viewModel.SelectedGenreIds)
                    {
                        var genre = _context.Genre.Find(genreId);
                        if (genre != null)
                        {
                            movie.Genre.Add(genre);
                        }
                    }
                }
            }
            else
            {
                
                var movieInDb = _context.Movies.Include(m => m.Genre).FirstOrDefault(m => m.Id == movie.Id);
                // TryUpdateModel(movieInDb);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.Stock = movie.Stock;
                movieInDb.Genre.Clear();
                movieInDb.Genre = new List<Genre>();
                foreach (var genreId in viewModel.SelectedGenreIds)
                {
                    var genre = _context.Genre.Find(genreId);
                    if (genre != null)
                    {
                        movieInDb.Genre.Add(genre);
                    }
                }

            }

            


            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

    }
}