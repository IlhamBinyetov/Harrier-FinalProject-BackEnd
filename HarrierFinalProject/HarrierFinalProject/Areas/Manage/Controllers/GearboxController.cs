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
    public class GearboxController : Controller
    {
        private readonly AppDbContext _context;

        public GearboxController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Gearbox> gearboxes = _context.Gearboxes.ToList();

            GearboxViewModel gearboxVM = new GearboxViewModel()
            {
                Gearboxes = gearboxes
            };

            return View(gearboxVM);
        }

        [HttpGet]
        public IActionResult Create()
        {
            List<Gearbox> gearboxes = _context.Gearboxes.ToList();

            GearboxViewModel gearboxVM = new GearboxViewModel()
            {
                Gearboxes = gearboxes
            };

            return View(gearboxVM);
        }

        [HttpPost]
        public IActionResult Create(GearboxViewModel gearboxVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Gearbox gearbox = new Gearbox()
            {
                Name = gearboxVM.Name
            };


            _context.Gearboxes.Add(gearbox);
            _context.SaveChanges();

            return RedirectToAction("index");
        }


        [HttpGet]
        public IActionResult Edit(int id)

        {
            Gearbox gearbox = _context.Gearboxes.FirstOrDefault(c => c.Id == id);


            GearboxViewModel gearboxVM = new GearboxViewModel
            {
                Gearbox = gearbox

            };



            if (gearbox == null) return NotFound();

            return View(gearboxVM);
        }




        [HttpPost]
        public IActionResult Edit(int id, GearboxViewModel gearBoxVM)
        {
            if (!ModelState.IsValid) return View();

            Gearbox existGearbox = _context.Gearboxes.FirstOrDefault(x => x.Id == id);

            if (existGearbox == null) return NotFound();


            existGearbox.Name = gearBoxVM.Name;


            _context.SaveChanges();

            return RedirectToAction("index");
        }


        public IActionResult DeleteFetch(int id)
        {
            Gearbox gearbox = _context.Gearboxes.FirstOrDefault(x => x.Id == id);

            if (gearbox == null) return Json(new { status = 404 });

            try
            {
                _context.Gearboxes.Remove(gearbox);
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
