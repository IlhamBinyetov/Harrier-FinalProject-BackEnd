using HarrierFinalProject.Areas.Manage.ViewModels;
using HarrierFinalProject.Data;
using HarrierFinalProject.Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrierFinalProject.Areas.Manage.Controllers
{
    [Area("manage")]
    public class CarController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public CarController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int page=1, string search=null)
        {
            List<Car> cars = _context.Cars.Include(c=>c.Brand).Include(c=>c.Model).Include(c=>c.CarImages).ToList();

            ViewBag.CurrenSearch = search;

            CarViewModel carVM = new CarViewModel()
            {
                Cars = cars
            };


            return View(carVM);
        }
    }
}
