using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using UserProject1.Helpers;
using UserProject1.Models;

namespace UserProject1.Controllers
{
    public class PaymentController : Controller
    {
        a1Context context = new a1Context();

        
        public IActionResult Charge(string stripeEmail, string stripeToken)
        {

            int userId = Convert.ToInt32(TempData["uid"]);
            int bookId = Convert.ToInt32(TempData["bookingId"]);
            var bookmovie = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "bookmovie");
            ViewBag.bookmovie = bookmovie;
            ViewBag.total = bookmovie.Sum(item => item.Movies.MoviePrice * item.Quantity);


            UserDetails user = context.UserDetails.Where(u => u.UserDetailId == userId).SingleOrDefault();
            Bookings book = context.Bookings.Where(u => u.BookingId == bookId).SingleOrDefault();



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
            Payments payment = new Payments();
            {
                payment.UserDetailId = user.UserDetailId;
                payment.BookingId = book.BookingId;
                payment.StripePaymentId = charge.PaymentMethodId;
                payment.Amount = ViewBag.total;
                payment.CreatedDate = DateTime.Now;
                payment.Description = "Visa";
                payment.Card = Convert.ToInt32(charge.PaymentMethodDetails.Card.Last4);
            }

            context.Add<Payments>(payment);
            context.Payments.Add(payment);
            context.SaveChanges();


            //var customerService = new CustomerService();
            //ViewBag.details = charge.PaymentMethodDetails.Card.Last4;

            return View();
            }
            public IActionResult Index()
            {
            
            return View();
            }

            public IActionResult Error()
            {
                return View();
            }
        
    }
}