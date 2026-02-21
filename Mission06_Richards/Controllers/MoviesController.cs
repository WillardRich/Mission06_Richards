using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Richards.Data;
using Mission06_Richards.Models;
using System.Security.Cryptography.X509Certificates;

namespace Mission06_Richards.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieContext _context;

        public MoviesController(MovieContext context)
        {
            _context = context;
        }

        public IActionResult Table()
        {
            var movies = _context.Movies
                .Include(m => m.Category)
                .ToList();
            return View(movies);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Add(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();
                return RedirectToAction("Table");
            }

            ViewBag.Categories = _context.Categories.ToList();
            return View(movie);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie == null)
            {
                return NotFound();
            }

            ViewBag.Categories = _context.Categories.ToList();

            return View(movie);
        }

        
      [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Update(movie);
                _context.SaveChanges();
                return RedirectToAction("Table");
            }

            ViewBag.Categories = _context.Categories.ToList();
            return View(movie);
        }
    
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie == null)
            {
                return NotFound(id);
            }
            return View(movie);

        }
        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return RedirectToAction("Table");
        }
    }

}
