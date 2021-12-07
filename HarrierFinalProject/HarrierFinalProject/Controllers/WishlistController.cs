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
    public class WishlistController : Controller
    {
        private readonly AppDbContext _context;

        public WishlistController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Car> cars = _context.Cars.Include(c => c.CarImages).Include(c=>c.Brand).Include(c=>c.Model).ToList();
            List<Advertising> advertisings = _context.Advertisings.ToList();

            WishlistViewModel wishlistVM = new WishlistViewModel()
            {
                Advertisings = advertisings,
                Cars = cars
            };
            

            return View(wishlistVM);
        }
    }
}
