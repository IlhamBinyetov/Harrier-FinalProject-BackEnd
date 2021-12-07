using HarrierFinalProject.Data;
using HarrierFinalProject.Data.Models;
using HarrierFinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrierFinalProject.Controllers
{
    public class CarController : Controller
    {
        private readonly AppDbContext _context;

        public CarController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Car> cars = _context.Cars.Include(c => c.Brand)
                                        .Include(c => c.Model)
                                        .Include(c => c.CarImages)
                                        .ToList();


            CarViewModel carVM  = new CarViewModel()
            {
                Cars = cars,
                Advertisings = _context.Advertisings.ToList(),
                CarTypes = _context.CarTypes.ToList()

            };


            ViewBag.PopularCars = _context.Cars.Include(c => c.Brand)
                                        .Include(c => c.Model)
                                        .Include(c => c.CarImages)
                                        .Take(5)
                                        .ToList();


            return View(carVM);
        }

        public IActionResult Detail(int id)
        {


            ViewBag.RelatedCars = _context.Cars.Include(c => c.Brand)
                                        .Include(c => c.Model)
                                        .Include(c => c.CarImages)
                                        .Take(4)
                                        .ToList();

            ViewBag.Advertisements = _context.Advertisings.ToList();


            Car car = _context.Cars.Include(c => c.CarImages)
                                   .Include(c => c.Model)
                                   .Include(c => c.CarStatus)
                                   .Include(c => c.CarType)
                                   .Include(c => c.CarColor)
                                   .Include(c=> c.CarFeatures)
                                   .ThenInclude(c => c.Feature)
                                   .Include(c => c.Transmission)
                                   .Include(c => c.Gearbox)
                                   .Include(c => c.Brand)
                                   .Include(c => c.City)
                                   .Include(c => c.FuelType)
                                   .Include(c=> c.Comments)
                                   .FirstOrDefault(x => x.Id == id);



            return View(car);
        }
    }
}
