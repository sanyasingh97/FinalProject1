using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserProject1.Helpers;
using UserProject1.Models;

namespace UserProject1.Controllers
{
    [Route("Location")]
    public class LocationController : Controller
    {

            a1Context context = new a1Context();
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
    }
