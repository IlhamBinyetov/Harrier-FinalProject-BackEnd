using HarrierFinalProject.Areas.Manage.ViewModels;
using HarrierFinalProject.Data;
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
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            var cars = _context.Cars.ToList();

            DashViewModel dashVM = new DashViewModel()
            {
                Cars = cars
            };

            return View(dashVM);
        }
    }
}
