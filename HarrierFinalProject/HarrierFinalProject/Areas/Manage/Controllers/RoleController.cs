using HarrierFinalProject.Data;
using HarrierFinalProject.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrierFinalProject.Areas.Manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class RoleController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(UserManager<AppUser> userManager, AppDbContext context, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _context = context;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            List<IdentityRole> roles = _context.Roles.ToList();
            return View(roles);
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IdentityRole role)
        {
            if (!ModelState.IsValid) return View();

            await _roleManager.CreateAsync(role);
            await _roleManager.UpdateAsync(role);


            return RedirectToAction("index", "role");
        }


        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult Edit(string name)
        {
            IdentityRole role = _roleManager.Roles.FirstOrDefault(x => x.Name == name);
            if (role == null) return RedirectToAction("index", "Error");
            TempData["name"] = name;

            return View(role);
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Edit(IdentityRole identityRole)
        {
            var name = TempData["name"];
            IdentityRole existRole = _roleManager.Roles.FirstOrDefault(x => x.Name == name.ToString());
            if (existRole == null) return RedirectToAction("index", "Error");
            existRole.Name = identityRole.Name;

            await _roleManager.UpdateAsync(existRole);

            return RedirectToAction("index", "role");
        }

        public async Task<IActionResult> Delete(string name)
        {

            IdentityRole deleteRole = _roleManager.Roles.FirstOrDefault(x => x.Name == name);
            await _roleManager.DeleteAsync(deleteRole);

            return RedirectToAction("index", "role");
        }
    }
}
