using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserProjectPart1.Models;

namespace UserProjectPart1.Controllers
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

