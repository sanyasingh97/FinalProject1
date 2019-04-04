﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserProject1.Helpers;
using UserProject1.Models;

namespace UserProject1.Controllers
{
    [Route("BookMovie")]
    public class BookMovieController : Controller
    {
        a1Context context = new a1Context();
        [Route("Index")]
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
            return RedirectToAction("Index","Home");
        }
        [Route("remove/{id}")]
        public IActionResult Remove(int id)
        {
            List<Item> bookmovie = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "bookmovie");
            int index = isExist(id);
            bookmovie.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "bookmovie", bookmovie);
            return RedirectToAction("GoBack");
        }
        [Route("goback")]
        public IActionResult GoBack()
        {
            return View();
        }
        [Route("Plus/{id}")]
        public IActionResult Plus(int id)
        {
            List<Item> bookmovie = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "bookmovie");
            int index = isExist(id);
            if (index != -1)
            {
                bookmovie[index].Quantity++;
            }
            else
            {
                bookmovie.Add(new Item
                {
                    Movies = context.Movies.Find(id),
                    Quantity = 1
                });

            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, "bookmovie", bookmovie);
            return RedirectToAction("Index");
        }


        [Route("Minus/{id}")]
        [HttpGet]
        public IActionResult Minus(int id)
        {
            List<Item> bookmovie = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "bookmovie");
            int index = isExist(id);
            if (index != -1)
            {
                if (bookmovie[index].Quantity != 1)
                {
                    bookmovie[index].Quantity--;
                }

                else
                    return RedirectToAction("Remove", "bookmovie", new { @id = id });
            }
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
        [Route("Checkout")]
        public IActionResult Checkout()
        {
            var id = int.Parse(TempData["uid"].ToString());
            var userDetails = context.UserDetails.Where(x => x.UserDetailId == id).SingleOrDefault();
            //UserDetails userDetails = context.UserDetails.Where(x => x.UserDetailId == id).SingleOrDefault();
            //ViewBag.UserDetails = userDetails;

            var bookmovie = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "bookmovie");
            ViewBag.bookmovie = bookmovie;
            ViewBag.total = bookmovie.Sum(item => item.Movies.MoviePrice * item.Quantity);
            //ViewBag.totalitem = bookmovie.Count();
            TempData["total"] = ViewBag.total;
            TempData["uid"] = id;
            return View(userDetails);
        }
        [Route("Checkout")]
        [HttpPost]

        public IActionResult Checkout(UserDetails userDetails)
        {
            //context.UserDetails.Add(userDetails);
            //context.SaveChanges();
            var amount = (TempData["total"]);
            var uid = (TempData["uid"]).ToString();
            Bookings bookings = new Bookings()
            {
                BookingAmount = Convert.ToSingle(amount),
                BookingDate = DateTime.Now,
                UserDetailId = int.Parse(uid)
                //UserDetailId = userDetails.UserDetailId
            };
            ViewBag.book = bookings;
            context.Bookings.Add(bookings);
            context.SaveChanges();


            var bookmovie = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "bookmovie");
            List<BookingDetails> BookingDetail = new List<BookingDetails>();
            for (int i = 0; i < bookmovie.Count; i++)
            {
                BookingDetails booking = new BookingDetails()
                {
                    BookingId = bookings.BookingId,
                    MovieId = bookmovie[i].Movies.MovieId,
                    QtySeats = bookmovie[i].Quantity
                };
                context.BookingDetails.Add(booking);
            }
            BookingDetail.ForEach(n => context.BookingDetails.Add(n));
            context.SaveChanges();
            TempData["cust"] = /*userDetails.UserDetailId*/uid;
            ViewBag.bookings = null;

              return RedirectToAction("Invoice");
        }
        [Route("Invoice")]
        public IActionResult Invoice()
        {
           int custId = int.Parse(TempData["cust"].ToString());
            UserDetails userDetails = context.UserDetails.Where(x => x.UserDetailId == custId).SingleOrDefault();
            ViewBag.UserDetails = userDetails;

            var bookmovie = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "bookmovie");
           ViewBag.bookmovie = bookmovie;

          ViewBag.Total = bookmovie.Sum(item => item.Movies.MoviePrice * item.Quantity);
            return View();
            
        }
        public IActionResult Books()
        {
            var movies = context.Movies.ToList();
            int j = 0;
            var bookmovie = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "bookmovie");
            int i = 0;
            if (bookmovie != null)
            {
                foreach (var item in bookmovie)
                {
                    i++;
                }
                if (i != 0)
                {
                    foreach (var i1 in bookmovie)
                    {
                        j++;
                    }
                    HttpContext.Session.SetString("cartitem", j.ToString());
                }
            }
            return View(movies);
        }

    }
}
