using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserProject1.Helpers;
using UserProject1.Models;

namespace UserProject1.Controllers
{
    [Route("Multiplex")]
    public class MultiplexController : Controller
    {
        a1Context context = new a1Context();
        //[Route("Index")]
        public IActionResult Index(int id)
        {
           
            ViewBag.multiplex = context.Multiplexes.ToList();
            int count = 0;
            if (ViewBag.multiplex != null)
            {
                foreach( var item in ViewBag.multiplex)
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