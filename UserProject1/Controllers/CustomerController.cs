using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UserProject1.Models;

namespace UserProject1.Controllers
{
    [Route("customer")]
    public class CustomerController : Controller
    {
        a1Context context = new a1Context();


        public IActionResult Index()
        {
            return View();
        }

        [Route("login")]
        
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var user = context.UserDetails.Where(x => x.UserName == username && x.Password == password).SingleOrDefault();
            if (user == null)
            {
                ViewBag.Error = "Invalid Credentials";
                return View("Index");
            }
            else

            {

                var userName = user.UserName;
                var Passwords = user.Password;
                TempData["uid"] = user.UserDetailId;
                if (username != null && password != null && username.Equals(userName) && password.Equals(Passwords))
                {
                    HttpContext.Session.SetString("uname", username);

                    return RedirectToAction("Checkout", "BookMovie");
                }
                else
                {
                    ViewBag.error = "Invalid Credentials";
                    return View("Index");
                }
            }
        }

        [Route("register")]

        [HttpGet]
        public ViewResult Register()
        {
            return View();
        }
        [Route("register")]
        [HttpPost]
        public IActionResult Register(UserDetails c1)
        {
            context.UserDetails.Add(c1);
            context.SaveChanges();
            TempData["uid"] = c1.UserDetailId;
            return RedirectToAction("Checkout", "BookMovie");
        }
    }
}

    
