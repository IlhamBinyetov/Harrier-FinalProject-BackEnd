using HarrierFinalProject.Areas.Manage.ViewModels;
using HarrierFinalProject.Data;
using HarrierFinalProject.Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HarrierFinalProject.Areas.Manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SliderController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            List<Slider> sliders = _context.Sliders.ToList();

            SliderViewModel sliderVM = new SliderViewModel()
            {
                Sliders = sliders
            };

            return View(sliderVM);
        }


        [HttpGet]
        public IActionResult Create()
        {
            List<Slider> sliders = _context.Sliders.ToList();

            SliderViewModel sliderVM = new SliderViewModel()
            {
                Sliders = sliders
            };


            return View(sliderVM);
        }

        [HttpPost]

        public IActionResult Create(SliderViewModel sliderVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Slider slider = new Slider()
            {
                Image = sliderVM.Image,
                ImageFile = sliderVM.ImageFile
                
            };


            if(slider.ImageFile != null)
            {
                if (slider.ImageFile.ContentType != "image/png" && slider.ImageFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "File type can be only jpeg,jpg or png!");
                    return View();
                }


                if (slider.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "File size can not be more than 2MB!");
                    return View();
                }

                string fileName = slider.ImageFile.FileName;
                if (fileName.Length > 64)
                {
                    fileName = fileName.Substring(fileName.Length - 64, 64);
                }

                string newFileName = Guid.NewGuid().ToString() + fileName;
                string path = Path.Combine(_env.WebRootPath, "assets/images", newFileName);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    slider.ImageFile.CopyTo(stream);
                }

                slider.Image = newFileName;
            }

            _context.Sliders.Add(slider);
            _context.SaveChanges();

            return RedirectToAction("index");
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {

            Slider slider = _context.Sliders.FirstOrDefault(c => c.Id == id);


            SliderViewModel sliderVM = new SliderViewModel
            {
                Slider = slider

            };

            if (slider == null) return NotFound();

            return View(sliderVM);

        }

        [HttpPost]
        public IActionResult Edit(int id, SliderViewModel sliderVM)
        {
            if (sliderVM.ImageFile == null) return View();


            if (!ModelState.IsValid) return View();


            Slider existSlider = _context.Sliders.FirstOrDefault(x => x.Id == id);

            if (existSlider == null) return NotFound();

           

            string newFileName = null;
            if (sliderVM.ImageFile != null)
            {
                if (sliderVM.ImageFile.ContentType != "image/png" && sliderVM.ImageFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "File type can be only jpeg,jpg or png!");
                    return View();
                }


                if (sliderVM.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "File size can not be more than 2MB!");
                    return View();
                }

                newFileName = Guid.NewGuid().ToString() + sliderVM.ImageFile.FileName;
                string path = Path.Combine(_env.WebRootPath, "assets/images", newFileName);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    sliderVM.ImageFile.CopyTo(stream);
                }

            }



            if (newFileName != null || sliderVM.Image == null)
            {
                if (existSlider.Image != null)
                {
                    string deletePath = Path.Combine(_env.WebRootPath, "assets/images", existSlider.Image);

                    if (System.IO.File.Exists(deletePath))
                    {
                        System.IO.File.Delete(deletePath);
                    }
                }

                existSlider.Image = newFileName;
            }

            existSlider.Image = newFileName;
            existSlider.ImageFile = sliderVM.ImageFile;


            _context.SaveChanges();
            return RedirectToAction("index");
        }


        public IActionResult DeleteFetch(int id)
        {
            Slider slider = _context.Sliders.FirstOrDefault(x => x.Id == id);

            if (slider == null) return Json(new { status = 404 });

            try
            {
                _context.Sliders.Remove(slider);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return Json(new { status = 500 });
            }
            string deletePath = Path.Combine(_env.WebRootPath, "assets/images", slider.Image);

            if (System.IO.File.Exists(deletePath))
            {
                System.IO.File.Delete(deletePath);
            }

            return Json(new { status = 200 });


        }



    }
}
