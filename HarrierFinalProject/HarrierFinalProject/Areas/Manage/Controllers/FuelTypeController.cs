using HarrierFinalProject.Areas.Manage.ViewModels;
using HarrierFinalProject.Data;
using HarrierFinalProject.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrierFinalProject.Areas.Manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class FuelTypeController : Controller
    {
        private readonly AppDbContext _context;

        public FuelTypeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<FuelType> fuelTypes = _context.FuelTypes.ToList();

            FuelTypeViewModel fuelTypeVM = new FuelTypeViewModel()
            {
                FuelTypes = fuelTypes
            };

            return View(fuelTypeVM);
        }

        [HttpGet]
        public IActionResult Create()
        {
            List<FuelType> fuelTypes = _context.FuelTypes.ToList();

            FuelTypeViewModel fuelTypeVM = new FuelTypeViewModel()
            {
                FuelTypes = fuelTypes
            };

            return View(fuelTypeVM);
        }


        [HttpPost]
        public IActionResult Create(FuelTypeViewModel fuelTypeVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            FuelType fuelType = new FuelType()
            {
                Name = fuelTypeVM.Name
            };


            _context.FuelTypes.Add(fuelType);
            _context.SaveChanges();

            return RedirectToAction("index");
        }


        [HttpGet]
        public IActionResult Edit(int id)

        {
            FuelType fuelType = _context.FuelTypes.FirstOrDefault(c => c.Id == id);


            FuelTypeViewModel fuelTypeVM = new FuelTypeViewModel
            {
                FuelType = fuelType

            };

            if (fuelType == null) return RedirectToAction("index", "Error");

            return View(fuelTypeVM);
        }

        [HttpPost]
        public IActionResult Edit(int id, FuelTypeViewModel fuelTypeVM)
        {
            if (!ModelState.IsValid) return View();

            FuelType existFuelType = _context.FuelTypes.FirstOrDefault(x => x.Id == id);

            if (existFuelType == null) return RedirectToAction("index", "Error");


            existFuelType.Name = fuelTypeVM.Name;


            _context.SaveChanges();

            return RedirectToAction("index");
        }


        public IActionResult DeleteFetch(int id)
        {
            FuelType fuelType = _context.FuelTypes.FirstOrDefault(x => x.Id == id);

            if (fuelType == null) return Json(new { status = 404 });

            try
            {
                _context.FuelTypes.Remove(fuelType);
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
