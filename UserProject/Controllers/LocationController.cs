using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserProject.Models;

namespace AdminProject.Controllers
{
    public class LocationController : Controller
    {
        FinalProjectDataDbContext context = new FinalProjectDataDbContext();
        public IActionResult Index()
        {
            {
                var locations = context.Locations.ToList();
                return View(locations);
            }
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Location location = context.Locations.Find(id);

            return View(location);
        }

        [HttpPost]
        public ActionResult Delete(int id, Location a1)
        {
            var location = context.Locations.Where(x => x.LocationId == id).SingleOrDefault();
            context.Locations.Remove(location);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ViewResult Create()
        {
            var locations = context.Locations.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind("LocationName")] Location a1)
        {
            if (ModelState.IsValid)
            {
                context.Locations.Add(a1);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(a1);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            Location location = context.Locations.Where(x => x.LocationId == id).SingleOrDefault();
            return View(location);
        }
        [HttpPost]
        public ActionResult Edit(int id, Location a1)
        {
            Location location = context.Locations.Where(x => x.LocationId == id).SingleOrDefault();

            location.LocationName = a1.LocationName;
            location.LocationImage = a1.LocationImage;
            context.SaveChanges();
            return RedirectToAction("Index");

        }
        public ViewResult Details(int id)
        {
            Location location = context.Locations.Where(x => x.LocationId == id).SingleOrDefault();
            return View(location);
        }
    }
}
