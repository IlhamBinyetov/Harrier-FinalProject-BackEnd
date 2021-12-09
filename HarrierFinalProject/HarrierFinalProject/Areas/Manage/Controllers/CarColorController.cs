using HarrierFinalProject.Data;
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


            return View();
        }
    }
}
