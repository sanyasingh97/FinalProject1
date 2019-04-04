using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserProjectPart1.Helpers;
using UserProjectPart1.Models;

namespace UserProjectPart1.Controllers
{

    [Route("BookMovie")]
    public class BookMovieController : Controller
    {
        ProjectTestDataContext context = new ProjectTestDataContext();
        [Route("index")]
        public IActionResult Index()
        {
            var bookmovie = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "bookmovie");
            ViewBag.bookmovie = bookmovie;
            ViewBag.total = bookmovie.Sum(item => item.Movies.MoviePrice * item.Quantity);
            return View();
        }
        [Route("book/{id}")]
        public IActionResult Book(int id)
        {
            if (SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "bookmovie") == null)
            {
                List<Item> bookmovie = new List<Item>();
                bookmovie.Add(new Item { Movies = context.Movies.Find(id), Quantity = 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "bookmovie", bookmovie);
            }
            else
            {
                List<Item> bookmovie = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "bookmovie");
                int index = isExist(id);
                if (index != -1)
                {
                    bookmovie[index].Quantity++;
                }
                else
                {
                    bookmovie.Add(new Item { Movies = context.Movies.Find(id), Quantity = 1 });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "bookmovie", bookmovie);
            }
            return RedirectToAction("Index");
        }
        [Route("remove/{id}")]
        public IActionResult Remove(int id)
        {
            List<Item> bookmovie = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "bookmovie");
            int index = isExist(id);

            bookmovie.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "bookmovie", bookmovie);
            return RedirectToAction("Index");
        }
        private int isExist(int id)
        {
            List<Item> bookmovie = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "bookmovie");
            for (int i = 0; i < bookmovie.Count; i++)
            {
                if (bookmovie[i].Movies.MovieId.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }
        [Route("Details/{id}")]
        public IActionResult Details(int id)
        {
            var movie = context.Movies.Find(id);

            return View(movie);
        }
        
        public IActionResult Checkout()
        {
            var bookmovie = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "bookmovie");
            ViewBag.bookmovie = bookmovie;
            ViewBag.total = bookmovie.Sum(item => item.Movies.MoviePrice * item.Quantity);
           
            return View();
          
        }
        [HttpPost]
        public IActionResult Checkout(UserDetails UserDetails)
        {

                context.UserDetails.Add(UserDetails);
                context.SaveChanges();
                return RedirectToAction("Index");
          

        }
       
    }
}