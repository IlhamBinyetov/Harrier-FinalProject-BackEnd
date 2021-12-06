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
    public class HomeController:Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(HomeViewModel homeVM)
        {      
            List<Car> cars = _context.Cars.Include(c => c.Brand)
                                          .Include(c=>c.Model)
                                          .Include(c => c.CarFeatures)
                                          .Include(c => c.CarImages)
                                          .Include(c => c.Gearbox)
                                          .Include(c => c.Transmission)
                                          .Include(c=>c.CarStatus) 
                                          .ToList();

            homeVM = new HomeViewModel()
            {
                Sliders = _context.Sliders.ToList(),
                CarTypes = _context.CarTypes.ToList(),
                Comments = _context.Comments.ToList(),
                Cars = cars,
                Partners = _context.Partners.ToList(),
                Blogs = _context.Blogs.ToList(),
                Advertisings = _context.Advertisings.ToList()
            
            };

            return View(homeVM);
        }

        public IActionResult AdvancedSearch()
        {
            return View();
        }
    }
}
