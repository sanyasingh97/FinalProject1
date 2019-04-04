using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UserProject.Models;

namespace AdminProject.Controllers
{
    public class MovieController : Controller
    {
        FinalProjectDataDbContext context = new FinalProjectDataDbContext();
        public IActionResult Index()
        {
            var movies = context.Movies.ToList();
            return View(movies);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Movie movie = context.Movies.Find(id);

            return View(movie);
        }
        [HttpPost]
        public ActionResult Delete(int id, Movie m1)
        {
            var author = context.Movies.Where(x => x.MovieId == id).SingleOrDefault();
            context.Movies.Remove(author);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Movie movie = context.Movies.Where(x => x.MovieId == id).SingleOrDefault();
            return View(movie);
        }

        [HttpPost]
        public ActionResult Edit(int id, Movie m1)
        {
            Movie movie = context.Movies.Where(x => x.MovieId == id).SingleOrDefault();
            movie.MovieName = m1.MovieName;
            movie.MoviePrice = m1.MoviePrice;
            movie.MovieDescription = m1.MovieDescription;
            movie.MovieDuration = m1.MovieDuration;
            movie.MovieImage = m1.MovieImage;
            //movie.AuditoriumId = m1.AuditoriumId;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ViewResult Details(int id)
        {
            Movie movie = context.Movies.Where(x => x.MovieId == id).SingleOrDefault();
            return View(movie);
        }
        [HttpGet]
        public ViewResult Create()
        {
            ViewBag.auditorium = new SelectList(context.Auditoriums, "AuditoriumId", "AuditoriumName");
            var movies = context.Movies.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Movie m1)
        {
            context.Movies.Add(m1);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}