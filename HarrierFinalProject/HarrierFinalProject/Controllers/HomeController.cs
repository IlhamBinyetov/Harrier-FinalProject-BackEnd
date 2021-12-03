using HarrierFinalProject.Data;
using HarrierFinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
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
            homeVM = new HomeViewModel()
            {
                Sliders = _context.Sliders.ToList(),
                CarTypes = _context.CarTypes.ToList(),
                Comments = _context.Comments.ToList()
            };

            return View(homeVM);
        }
    }
}
