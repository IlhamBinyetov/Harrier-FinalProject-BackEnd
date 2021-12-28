using HarrierFinalProject.Areas.Manage.ViewModels;
using HarrierFinalProject.Data;
using HarrierFinalProject.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrierFinalProject.Areas.Manage.Controllers
{
    [Area("manage")]
    //[Authorize(Roles = "SuperAdmin, Admin")]
    public class ModelController : Controller
    {
        private readonly AppDbContext _context;

        public ModelController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int page = 1, string search=null)
        {
            if (page <= 0)
            {
                page = 1;
            }

            var query = _context.Models.Include(x => x.Brand).AsQueryable();


            ViewBag.CurrenSearch = search;

            if (!string.IsNullOrWhiteSpace(search))
                query = query.Where(x => x.Brand.Name.Contains(search) || x.Name.Contains(search));

            List<Model> models = query.Skip((page - 1) * 8).Take(8).ToList();

            ViewBag.TotalPage = Math.Ceiling(query.Count() / 8m);
            ViewBag.SelectedPage = page;



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
        public IActionResult  Edit(int id)

        {
            Model model = _context.Models.Include(m=>m.Brand).FirstOrDefault(m => m.Id == id);

            List<Brand> brands = _context.Brands.ToList();

            ModelViewModel modelVM = new ModelViewModel
            {
                Brands = brands,
                Model = model
                
            };

            if (model == null) return NotFound();

            return View(modelVM);
        }

        [HttpPost]
        public IActionResult Edit(int id, ModelViewModel modelVM)
        {
            if (!ModelState.IsValid) return View();

            Model existModel = _context.Models.FirstOrDefault(x => x.Id ==id);

            if (existModel == null) return NotFound();


            existModel.Name = modelVM.Model.Name;
            existModel.BrandId = modelVM.BrandId;

            _context.SaveChanges();

            return RedirectToAction("index");
        }



        public IActionResult DeleteFetch(int id)
        {
            Model model = _context.Models.FirstOrDefault(x => x.Id == id);

            if (model == null) return Json(new { status = 404 });

            try
            {
                _context.Models.Remove(model);
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
