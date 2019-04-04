using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserSideProject.Models;

namespace UserSideProject.Controllers
{
    public class HomeController : Controller
    {
        ProjectTestDataContext context = new ProjectTestDataContext();
        public IActionResult Index()
        {
            var movies = context.Movies.ToList();
            return View(movies);
        }
    }
}
