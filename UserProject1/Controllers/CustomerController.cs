using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UserProject1.Helpers;
using UserProject1.Models;

namespace UserProject1.Controllers
{
    [Route("customer")]
    public class CustomerController : Controller
    {
        
        a1Context context = new a1Context();


        [Route("Index")]

        [HttpGet]
        public IActionResult Index()
        {
            var user = HttpContext.Session.GetString("uid");
                 
            if (user != null)
            {

                int custId = int.Parse(HttpContext.Session.GetString("uid"));
                return RedirectToAction("Checkout", "BookMovie", new { @id = custId });
            }
            else
            {
                //ViewBag.Error = "Invalid Credentials";
                return View("Index");
          
            }
        }
        [Route("DirectLogin")]
        [HttpGet]
        public IActionResult DirectLogin()
        {
            return View("DirectLogin");
        }
        [Route("DirectLogin")]
        [HttpPost]
        public IActionResult DirectLogin([Bind("UserName", "Password")]string username, string password)
        {
            if (ModelState.IsValid)
            {
                var user = context.UserDetails.Where(x => x.UserName == username && x.Password == password).SingleOrDefault();
                HttpContext.Session.SetString("uid", (user.UserDetailId).ToString());
                HttpContext.Session.SetString("uname", (user.UserName).ToString());
                return RedirectToAction("Index1", "Home");

            }
            return View();
        }

        [Route("Index")]

        [HttpPost]
        public ActionResult Index([Bind("UserName","Password")]string username, string password)
        {
            if(username == null && password == null)
            {
                ViewBag.Error = "Enter Your Credentials";
                return RedirectToAction("Index", "Customer");
            }
            else
            {
                var user = context.UserDetails.Where(x => x.UserName == username && x.Password == password).SingleOrDefault();
                if (user == null)
                {
                    ViewBag.Error = "Invalid Credentials";
                    return RedirectToAction("Index", "Customer");
                }
                else
                {
                    HttpContext.Session.SetString("uid", (user.UserDetailId).ToString());
                    HttpContext.Session.SetString("uname", (user.UserName).ToString());
                    return RedirectToAction("Checkout", "BookMovie");
                }
                
            }
            
        }
        
        [Route("movies")]
        public IActionResult Movies(int id)

        {
            var movies = context.Movies.Where(m => m.MultiplexId == id).ToList();
            return View(movies);
          
        }
        [Route("Logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("uid");
            HttpContext.Session.Remove("uname");
            return RedirectToAction("Index1", "Home");
        }

        [Route("ChangePassword")]
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }
        [Route("ChangePassword")]
        [HttpPost]
        public IActionResult ChangePassword(string oldpassword, string newpassword, string newpassword1)
        {
            int id = int.Parse(HttpContext.Session.GetString("uid"));
            UserDetails c = context.UserDetails.Where(x => x.UserDetailId == id).SingleOrDefault();
            if (oldpassword == c.Password && newpassword == newpassword1)
            {
                UserDetails cus = context.UserDetails.Where(x => x.UserName == c.UserName).SingleOrDefault();
                cus.Password = newpassword;
                SessionHelper.SetObjectAsJson(HttpContext.Session, "bookmovie", cus);
                context.SaveChanges();

            }
            else
            {
                ViewBag.Error = "  Invalid Credentials";
                return View("Password");
            }
            return RedirectToAction("Index", "Location");
        }
        [Route("Dashboard")]
        [HttpGet]
        public IActionResult Dashboard()
        {
            return View();
        }

        [Route("ViewProfile")]
        public IActionResult ViewProfile()
        {
            int id = int.Parse(HttpContext.Session.GetString("uid"));
            UserDetails c = context.UserDetails.Where(x => x.UserDetailId == id).SingleOrDefault();
            return View(c);
        }

        [Route("BookingDetails")]
        public IActionResult BookingDetails()
        {
            int id = int.Parse(HttpContext.Session.GetString("uid"));
          

            var c = context.Bookings.Where(x => x.UserDetailId == id).ToList();
          

           
           
            return View(c);
        }
  
    }
}

    
