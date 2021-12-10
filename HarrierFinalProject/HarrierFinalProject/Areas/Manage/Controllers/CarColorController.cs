﻿using HarrierFinalProject.Areas.Manage.ViewModels;
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
    public class CarColorController : Controller
    {
        private readonly AppDbContext _context;

        public CarColorController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            List<CarColor> carColors = _context.CarColors.ToList();

            CarColorViewModel CarColorVM = new CarColorViewModel()
            {
                CarColors = carColors
            };

            return View(CarColorVM);
        }

       
        [HttpGet]
        public IActionResult Create()
        {
            List<CarColor> carColors  = _context.CarColors.ToList();

            CarColorViewModel CarColorVM = new CarColorViewModel()
        {
            CarColors = carColors
        };

            return View(CarColorVM);
        }


        [HttpPost]
        public IActionResult Create(CarColorViewModel carColorVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            CarColor carColor = new CarColor()
            {
                Name = carColorVM.Name
            };



            _context.CarColors.Add(carColor);
            _context.SaveChanges();

            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Edit(int id)

        {
            CarColor carColor = _context.CarColors.FirstOrDefault(c => c.Id == id);


            CarColorViewModel carColorVM = new CarColorViewModel
            {
               CarColor = carColor

            };

            if (carColor == null) return NotFound();

            return View(carColorVM);
        }



        [HttpPost]
        public IActionResult Edit(int id, CarColorViewModel carColorVM)
        {
            if (!ModelState.IsValid) return View();

            CarColor existCarColor = _context.CarColors.FirstOrDefault(x => x.Id == id);

            if (existCarColor == null) return NotFound();


            existCarColor.Name = carColorVM.Name;
            

            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult DeleteFetch(int id)
        {
            CarColor carColor = _context.CarColors.FirstOrDefault(x => x.Id == id);

            if (carColor == null) return Json(new { status = 404 });

            try
            {
                _context.CarColors.Remove(carColor);
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