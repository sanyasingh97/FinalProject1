using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using UserProject1.Helpers;
using UserProject1.Models;

namespace UserProject1.Controllers
{
    [Route("BookMovie")]
    public class BookMovieController : Controller
    {
        public int discount = 100;
        public string audiName;
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
            return RedirectToAction("Index", "BookMovie");
        }

        [Route("remove/{id}")]
        public IActionResult Remove(int id)
        {
            List<Item> bookmovie = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "bookmovie");
            int index = isExist(id);
            if (index != -1)
            {
                bookmovie[index].Quantity--;
            }
            else
            {
                bookmovie.Add(new Item { Movies = context.Movies.Find(id), Quantity = 1 });
            }
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
        public void checkAudi(string showTiming)
        {
            if (showTiming == "12 Noon")
            {
                audiName = "Audi 1";
            }
            else if (showTiming == "3 PM")
            {
                audiName = "Audi 2";
            }
            else if (showTiming == "6 PM")
            {
                audiName = "Audi 3";
            }
        }
        [Route("Checkout")]
        public IActionResult Checkout()
        {
             var id = Convert.ToInt32(HttpContext.Session.GetString("uid"));
            var userDetails = context.UserDetails.Where(x => x.UserDetailId == id).SingleOrDefault();

            var bookmovie = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "bookmovie");

            if (bookmovie == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.bookmovie = bookmovie;
                ViewBag.total = bookmovie.Sum(item => item.Movies.MoviePrice * item.Quantity);
                //ViewBag.totalitem = bookmovie.Count();
                TempData["total"] = ViewBag.total;
                TempData["uid"] = id;
                return View(userDetails);
            }

        }
        [Route("Checkout")]
        [HttpPost]

        public IActionResult Checkout(UserDetails userDetails,Bookings bookings,  string stripeEmail, string stripeToken)
        {
            int userId = Convert.ToInt32(TempData["uid"]);


            ViewBag.bookmovie = TempData["total"];
            //ViewBag.total = bookmovie.Sum(item => item.Movies.MoviePrice * item.Quantity);


            UserDetails user = context.UserDetails.Where(u => u.UserDetailId == userId).SingleOrDefault();
            //Bookings book = context.Bookings.Where(b => b.BookingId == bookingId).SingleOrDefault();



            var customers = new CustomerService();
            var charges = new ChargeService();
            var customer = customers.Create(new CustomerCreateOptions
            {
                Email = stripeEmail,
                SourceToken = stripeToken
            });

            var charge = charges.Create(new ChargeCreateOptions
            {
                Amount = 500,
                Description = "Sample Charge",
                Currency = "usd",
                CustomerId = customer.Id
            });


            var bookmovie = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "bookmovie");

            var showTiming = Request.Form["showTiming"].ToString();
            var amount = (TempData["total"]);
            var uid = (TempData["uid"]).ToString();
           
            checkAudi(showTiming);

            Bookings booking = new Bookings()
            {
                BookingAmount = Convert.ToInt32(amount),
                BookingDate = DateTime.Now,
                ShowTiming = showTiming,
                AudiName = audiName,
                UserDetailId = Convert.ToInt32(uid),
            };

            context.Bookings.Add(booking);
            context.SaveChanges();

            List<BookingDetails> BookingDetail = new List<BookingDetails>();
            for (int i = 0; i < bookmovie.Count; i++)
            {
                BookingDetails bookingDetail = new BookingDetails()
                {
                    BookingId = booking.BookingId,
                    MovieId = bookmovie[i].Movies.MovieId,
                    QtySeats = bookmovie[i].Quantity
                };
                context.BookingDetails.Add(bookingDetail);
            }
            BookingDetail.ForEach(n => context.BookingDetails.Add(n));
            context.SaveChanges();

            Payments payment = new Payments();
            {
                payment.UserDetailId = int.Parse(HttpContext.Session.GetString("uid"));

                payment.BookingId = booking.BookingId;
                payment.StripePaymentId = charge.PaymentMethodId;
                payment.Amount = ViewBag.bookmovie;
                payment.CreatedDate = DateTime.Now;
                payment.Description = "VISA";
                payment.Card = Convert.ToInt32(charge.PaymentMethodDetails.Card.Last4);
            }
           
            context.Payments.Add(payment);
            context.SaveChanges();
            

            TempData.Keep("uid");
            TempData["bookingId"] = booking.BookingId;
            return RedirectToAction("Invoice", "BookMovie");
        }
        [Route("Invoice")]
        public IActionResult Invoice()
        {
            int userId = Convert.ToInt32(TempData["uid"]);
            int bookingId = Convert.ToInt32(TempData["bookingId"]);

            var bookmovie = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "bookmovie");
            UserDetails user = context.UserDetails.Where(u => u.UserDetailId == userId).SingleOrDefault();
            Bookings book = context.Bookings.Where(b => b.BookingId == bookingId).SingleOrDefault();

            ViewBag.bookmovie = bookmovie;
            ViewBag.Total = bookmovie.Sum(item => item.Movies.MoviePrice * item.Quantity);
            ViewBag.user = user;
            ViewBag.book = book;
            ViewBag.discount = discount;
            ViewBag.subtotal = ViewBag.Total - discount;
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
        public IActionResult Dashboard()
        {
            return View();
        }

        [Route("register")]
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [Route("register")]
        [HttpPost]
        public IActionResult Register(UserDetails userDetails)
        {
            if (ModelState.IsValid)
            {
                context.UserDetails.Add(userDetails);
                context.SaveChanges();
                HttpContext.Session.SetString("uid", (userDetails.UserDetailId).ToString());
                return RedirectToAction("Checkout", "BookMovie");
            }
            return View();
        }

        [HttpGet]
        public ActionResult DirectRegister()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DirectRegister(UserDetails userDetails)
        {
            if (ModelState.IsValid)
            {
                context.UserDetails.Add(userDetails);
                context.SaveChanges();
                HttpContext.Session.SetString("uid", (userDetails.UserDetailId).ToString());
                return RedirectToAction("Index", "Location");
            }
            return View();

        }

        public IActionResult Index1()
        {

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}

