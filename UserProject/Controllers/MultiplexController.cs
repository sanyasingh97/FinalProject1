using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UserProject.Models;

namespace UserProject.Controllers
{
    public class MultiplexController : Controller
    {
        FinalProjectDataDbContext context = new FinalProjectDataDbContext();
        public IActionResult Index()
        {
            var multiplexes = context.Multiplexes.ToList();
            return View(multiplexes);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Multiplex multiplex = context.Multiplexes.Find(id);

            return View(multiplex);
        }
        [HttpPost]
        public ActionResult Delete(int id, Multiplex m1)
        {
            var author = context.Multiplexes.Where(x => x.MultiplexId == id).SingleOrDefault();
            context.Multiplexes.Remove(author);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Multiplex multiplex = context.Multiplexes.Where(x => x.MultiplexId == id).SingleOrDefault();
            return View(multiplex);
        }

        [HttpPost]
        public ActionResult Edit(int id, Multiplex m1)
        {
            Multiplex multiplex = context.Multiplexes.Where(x => x.MultiplexId == id).SingleOrDefault();
            multiplex.MultiplexName = m1.MultiplexName;
            multiplex.MultiplexDescription = m1.MultiplexDescription;
            multiplex.MultiplexImage = m1.MultiplexImage;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ViewResult Details(int id)
        {
            Multiplex multiplex = context.Multiplexes.Where(x => x.MultiplexId == id).SingleOrDefault();
            return View(multiplex);
        }
        [HttpGet]
        public ViewResult Create()
        {
            ViewBag.location = new SelectList(context.Locations, "LocationId", "LocationName");
            var multiplexes = context.Multiplexes.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind("MultiplexName", "MultiplexDescription")] Multiplex m1)
        {
            if (ModelState.IsValid)
            {
                context.Multiplexes.Add(m1);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(m1);
        }
    }
}