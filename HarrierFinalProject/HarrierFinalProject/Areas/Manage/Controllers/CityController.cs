using HarrierFinalProject.Data;
using HarrierFinalProject.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrierFinalProject.Areas.Manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class CityController : Controller
    {
        private readonly AppDbContext _context;

        public CityController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int page = 1, string search=null)
        {
            if (page <= 0)
            {
                page = 1;
            }

            var query = _context.Cities.AsQueryable();

            ViewBag.CurrenSearch = search;

            if (!string.IsNullOrWhiteSpace(search))
                query = query.Where(x => x.Name.Contains(search));

            List<City> cities = query.Skip((page - 1) * 6).Take(6).ToList();

            ViewBag.TotalPage = Math.Ceiling(query.Count() / 6m);
            ViewBag.SelectedPage = page;

            return View(cities);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(City city)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _context.Cities.Add(city);
            _context.SaveChanges();

            return RedirectToAction("index");
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            City city = _context.Cities.FirstOrDefault(c => c.Id == id);

            if (city == null) return NotFound();

            return View(city);
        }

        [HttpPost]
        public IActionResult Edit(City city)
        {
            if (!ModelState.IsValid) return View();

            City existCity = _context.Cities.FirstOrDefault(x => x.Id == city.Id);

            if (existCity == null) return NotFound();


            existCity.Name = city.Name;



            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult DeleteFetch(int id)
        {
            City city = _context.Cities.FirstOrDefault(x => x.Id == id);

            if (city == null) return Json(new { status = 404 });

            try
            {
                _context.Cities.Remove(city);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return Json(new { status = 500 });
            }


            return Json(new { status = 200 });


        }
    }
}
