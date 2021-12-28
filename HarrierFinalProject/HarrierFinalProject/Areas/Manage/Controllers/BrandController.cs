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
    //[Authorize(Roles = "SuperAdmin, Admin")]
    public class BrandController : Controller
    {
        private readonly AppDbContext _context;

        public BrandController(AppDbContext context )
        {
            _context = context;
        }
        public IActionResult Index(int page=1, string search=null)
        {
            if (page <= 0)
            {
                page = 1;
            }

            var query = _context.Brands.AsQueryable();

            ViewBag.CurrenSearch = search;

            if (!string.IsNullOrWhiteSpace(search))
                query = query.Where(x => x.Name.Contains(search));

            List<Brand> brands = query.Skip((page - 1) * 8).Take(8).ToList();


            ViewBag.TotalPage = Math.Ceiling(query.Count() / 8m);
            ViewBag.SelectedPage = page;

           


            return View(brands);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Brand brand)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _context.Brands.Add(brand);
            _context.SaveChanges();

            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Brand brand = _context.Brands.FirstOrDefault(c => c.Id == id);

            if (brand == null) return NotFound();

            return View(brand);
        }

        [HttpPost]
        public IActionResult Edit(Brand brand)
        {
            if (!ModelState.IsValid) return View();

            Brand existBrand = _context.Brands.FirstOrDefault(x => x.Id == brand.Id);

            if (existBrand == null) return NotFound();


            existBrand.Name = brand.Name;



            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult DeleteFetch(int id)
        {
            Brand brand = _context.Brands.FirstOrDefault(x => x.Id == id);

            if (brand == null) return Json(new { status = 404 });

            try
            {
                _context.Brands.Remove(brand);
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
