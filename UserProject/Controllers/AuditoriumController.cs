using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UserProject.Models;

namespace AdminProject.Controllers
{
    public class AuditoriumController : Controller
    {
        FinalProjectDataDbContext context = new FinalProjectDataDbContext();
        public IActionResult Index()
        {
            var auditoriums = context.Auditoriums.ToList();
            return View(auditoriums);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Auditorium auditorium = context.Auditoriums.Find(id);

            return View(auditorium);
        }

        [HttpPost]
        public ActionResult Delete(int id, Auditorium a1)
        {
            var auditorium = context.Auditoriums.Where(x => x.AuditoriumId == id).SingleOrDefault();
            context.Auditoriums.Remove(auditorium);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ViewResult Create()
        {
            ViewBag.multiplex = new SelectList(context.Multiplexes, "MultiplexId", "MultiplexName");
            var auditoriums = context.Auditoriums.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Auditorium a1)
        {
            context.Auditoriums.Add(a1);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            Auditorium auditorium = context.Auditoriums.Where(x => x.AuditoriumId == id).SingleOrDefault();
            return View(auditorium);
        }
        [HttpPost]
        public ActionResult Edit(int id, Auditorium a1)
        {
            Auditorium auditorium = context.Auditoriums.Where(x => x.AuditoriumId == id).SingleOrDefault();

            auditorium.AuditoriumName = a1.AuditoriumName;
            auditorium.AuditoriumDescription = a1.AuditoriumDescription;
            auditorium.Seats = a1.Seats;
            auditorium.Time1 = a1.Time1;
            auditorium.Time2 = a1.Time2;
            auditorium.Time3 = a1.Time3;
            auditorium.MultiplexId = a1.MultiplexId;
            context.SaveChanges();
            return RedirectToAction("Index");

        }
        public ViewResult Details(int id)
        {
            Auditorium auditorium = context.Auditoriums.Where(x => x.AuditoriumId == id).SingleOrDefault();
            return View(auditorium);
        }
    }
}
    