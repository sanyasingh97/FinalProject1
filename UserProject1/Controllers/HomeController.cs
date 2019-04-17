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
        public IActionResult Locations()
        {
            return View();
        }
      
    }


}
    

      