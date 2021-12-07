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
    public class BasketController : Controller
    {
        private readonly AppDbContext _context;

        public BasketController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            List<Car> cars = _context.Cars.Include(c => c.CarImages).Include(c => c.Brand).Include(c => c.Model).ToList();
            List<Advertising> advertisings = _context.Advertisings.ToList();


            BasketViewModel basketVM = new BasketViewModel()
            {
                Advertisings = advertisings,
                Cars = cars
            };

            return View(basketVM);
        }
    }
}
