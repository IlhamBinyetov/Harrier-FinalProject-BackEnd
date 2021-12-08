using HarrierFinalProject.Areas.Manage.ViewModels;
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
    public class ModelController : Controller
    {
        private readonly AppDbContext _context;

        public ModelController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Model> models = _context.Models.ToList();

            ModelViewModel modelVM = new ModelViewModel()
            {
                Models = models
            };

            return View(modelVM);
        }

        [HttpGet]
        public IActionResult Create()
        {
            List<Brand> brands = _context.Brands.ToList();

            ModelViewModel modelVM = new ModelViewModel()
            {
                Brands = brands
            };

            return View(modelVM);
        }

        [HttpPost]
        public IActionResult Create(ModelViewModel modelVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Model model = new Model()
            {
                Name = modelVM.Name,
                BrandId = modelVM.BrandId
            };

            _context.Models.Add(model);
            _context.SaveChanges();

            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult  Edit(ModelViewModel modelVM)

        {


            return View(modelVM);
        }
    }
}
