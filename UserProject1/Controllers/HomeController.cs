using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserProject1.Helpers;
using UserProject1.Models;

namespace UserProject1.Controllers
{
    public class HomeController : Controller
    {
        a1Context context = new a1Context();
        public IActionResult Index()
        {
            var movies = context.Movies.ToList();
            return View(movies);
        }
        public IActionResult Contact()
        {
            return View();

        }
        public IActionResult Upcoming()
        {
            return View();

        }

        public IActionResult Movies()
        {
            return View();
        }
        public IActionResult Index1()
        {
            var location = context.Locations.ToList();
            return View(location);
        }
        public IActionResult Multiplex(int id)
        {
                ViewBag.multiplex = context.Multiplexes.ToList();
                int count = 0;
                if (ViewBag.multiplex != null)
                {
                    foreach (var item in ViewBag.multiplex)
                    {
                        count++;
                    }
                    if (count != 0)
                    {
                        HttpContext.Session.SetString("Location", count.ToString());
                    }
                }
                var booking = context.Multiplexes.Where(x => x.LocationId == id).ToList();
                ViewBag.Index = booking;
                TempData["location"] = id;
                return View(ViewBag.multiplex);
            }
        }
    }



      