using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoRentalProject.Models;
using System.Data.Entity;

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
            var Movie = _context.Movies.Include(m => m.Genre).FirstOrDefault(m=>m.id == id);
            return View(Movie);

        }


    }
}