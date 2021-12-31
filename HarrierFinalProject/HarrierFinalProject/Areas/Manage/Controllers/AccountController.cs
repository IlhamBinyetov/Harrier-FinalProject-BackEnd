using HarrierFinalProject.Areas.Manage.ViewModels;
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
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            //AppUser admin = new AppUser()
            //{
            //    UserName = "SuperAdmin",
            //    Fullname = "Super Admin"
            //};

            //var result = await _userManager.CreateAsync(admin, "Admin123");

            //IdentityRole role1 = new IdentityRole("SuperAdmin");
            //await _roleManager.CreateAsync(role1);
            //IdentityRole role2 = new IdentityRole("Admin");
            //await _roleManager.CreateAsync(role2);
            //IdentityRole role3 = new IdentityRole("Member");
            //await _roleManager.CreateAsync(role3);


            //AppUser appUser = await _userManager.FindByNameAsync("SuperAdmin");
            //await _userManager.AddToRoleAsync(appUser, "SuperAdmin");


            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginVM)

        {

            if (!ModelState.IsValid) return View();

            AppUser admin = _userManager.Users.FirstOrDefault(c => c.UserName == loginVM.UserName && c.IsAdmin==true);

            if(admin == null)
            {
                ModelState.AddModelError("", "Username or Password is incorrect");
                return View();

            }

            var result = await _signInManager.PasswordSignInAsync(admin, loginVM.Password, loginVM.IsPersistent, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "istifadeci adi ve ya sifre yanlisdir!");
                return View();
            }




            return RedirectToAction("index", "dashboard");
        }


        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("login", "account");
        }



        public IActionResult IndexAdmin()
        {
            var members = _userManager.Users.Where(x => x.IsAdmin == true).ToList();

            List<AdminViewModel> adminList = new List<AdminViewModel>();


            foreach (var item in members)
            {
                adminList.Add(new AdminViewModel()
                {
                    Id = item.Id,
                    UserName = item.UserName,
                    FullName = item.Fullname,
                    Email = item.Email
                });
            }


            return View(adminList);
        }

        [HttpGet]
        //[Authorize(Roles = "SuperAdmin")]
        public IActionResult CreateAdmin()
        {
            return View();
        }


        [HttpPost]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> CreateAdmin(AdminViewModel AdminVM)
        {
            AppUser admin = await _userManager.FindByNameAsync(AdminVM.UserName);
            if (admin != null)
            {
                ModelState.AddModelError("UserName", "UserName has  already been taken!");
                return View();
            }


            admin = await _userManager.FindByEmailAsync(AdminVM.Email);
            if (admin != null)
            {
                ModelState.AddModelError("Email", "Email has already been taken!");
                return View();
            }

            admin = new AppUser
            {
                IsAdmin = true,
                Fullname = AdminVM.FullName,
                UserName = AdminVM.UserName,
                Email = AdminVM.Email

            };


            var result = await _userManager.CreateAsync(admin, AdminVM.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View();
            }

            await _userManager.AddToRoleAsync(admin, "Admin");
            await _signInManager.SignInAsync(admin, true);

            return RedirectToAction("Index", "Dashboard");
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> EditAdmin(string id)
        {
           

            AppUser admin = await _userManager.FindByIdAsync(id);
            if (admin == null) return NotFound();
            AdminViewModel adminVM = new AdminViewModel()
            {
                AppUser = admin
            };
            return View(adminVM);
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> EditAdmin(AdminViewModel AdminVM)
        {

            if (!ModelState.IsValid) return View();

            AppUser existUser = await _userManager.FindByIdAsync(AdminVM.Id);

            if (existUser == null) return NotFound();

            existUser.Fullname = AdminVM.FullName;
            existUser.UserName = AdminVM.UserName;
            existUser.Email = AdminVM.Email;

            await _userManager.UpdateAsync(existUser);

            return RedirectToAction("index");
        }

        public async Task<IActionResult> Delete(string name)
        {

            AppUser deleteadmin = _userManager.Users.FirstOrDefault(x => x.UserName == name);

            await _userManager.DeleteAsync(deleteadmin);


            return RedirectToAction("IndexAdmin");
        }
    }
}
