using HarrierFinalProject.Areas.Manage.ViewModels;
using HarrierFinalProject.Data;
using HarrierFinalProject.Data.Models;
using Microsoft.AspNetCore.Authorization;
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
    public class SettingController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SettingController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            Setting setting = _context.Settings.FirstOrDefault();

            SettingViewModel settingVM = new SettingViewModel()
            {
                Setting = setting,
                SettingId = setting.Id
            };

            return View(settingVM);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Setting setting = _context.Settings.FirstOrDefault(s=>s.Id==id);

            if (setting == null) return NotFound();

            SettingViewModel settingVM = new SettingViewModel()
            {
                Setting = setting
            };

            return View(settingVM);
        }

        [HttpPost]
        public IActionResult Edit(int id, SettingViewModel settingVM)
        {
            if (settingVM.ImageFile == null) return View();

            if (!ModelState.IsValid) return View();

            Setting existSetting = _context.Settings.FirstOrDefault(s => s.Id == id);

            if (existSetting == null) return NotFound();


            string newFileName = null;
            if (settingVM.ImageFile != null)
            {
                if (settingVM.ImageFile.ContentType != "image/png" && settingVM.ImageFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "File type can be only jpeg,jpg or png!");
                    return View();
                }


                if (settingVM.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "File size can not be more than 2MB!");
                    return View();
                }

                newFileName = Guid.NewGuid().ToString() + settingVM.ImageFile.FileName;
                string path = Path.Combine(_env.WebRootPath, "assets/images", newFileName);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    settingVM.ImageFile.CopyTo(stream);
                }
            }

            if (newFileName != null || settingVM.Image == null)
            {
                if (existSetting.HeaderLogo != null)
                {
                    string deletePath = Path.Combine(_env.WebRootPath, "assets/images", existSetting.HeaderLogo);

                    if (System.IO.File.Exists(deletePath))
                    {
                        System.IO.File.Delete(deletePath);
                    }
                }

                existSetting.HeaderLogo = newFileName;
            }

            existSetting.HeaderLogo = newFileName;
            existSetting.Phone = settingVM.Setting.Phone;
            existSetting.Email = settingVM.Setting.Email;
            existSetting.Address = settingVM.Setting.Address;

            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
