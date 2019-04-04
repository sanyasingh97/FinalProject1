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

    }

}
    

      