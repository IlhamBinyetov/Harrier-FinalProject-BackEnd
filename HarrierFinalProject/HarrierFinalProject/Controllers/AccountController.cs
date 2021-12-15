using HarrierFinalProject.Data;
using HarrierFinalProject.Data.Models;
using HarrierFinalProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrierFinalProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(AppDbContext context, UserManager <AppUser> userManager, SignInManager<AppUser> signInManager )
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<IActionResult> Register(MemberRegisterViewModel memberRegisterVM)
        {
            if (!ModelState.IsValid) return View();

            AppUser member = await _userManager.FindByNameAsync(memberRegisterVM.FullName);


            if (member != null)
            {
                ModelState.AddModelError("UserName", "UserName has already been taken!");
                return View();
            }

            member = await _userManager.FindByEmailAsync(memberRegisterVM.Email);
            if (member != null)
            {
                ModelState.AddModelError("Email", "Email has already been taken!");
                return View();
            }

            member = new AppUser
            {
                Fullname = memberRegisterVM.FullName,
                UserName = memberRegisterVM.UserName,
                Email = memberRegisterVM.Email,
                IsAdmin = false
            };

            var result = await _userManager.CreateAsync(member, memberRegisterVM.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View();
            }

            var roleResult = await _userManager.AddToRoleAsync(member, "Member");
            await _signInManager.SignInAsync(member, true);

            return RedirectToAction("index", "home");

            
        }



        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(MemberLoginViewModel memberLoginVM)
        {
            if (!ModelState.IsValid) return View();

            AppUser member = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == memberLoginVM.UserName && !x.IsAdmin);

            if (member == null)
            {
                ModelState.AddModelError("", "username or password incorrect!");
                return View();
            }

            var result = await _signInManager.PasswordSignInAsync(member, memberLoginVM.Password, true, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "username or password incorrect!");
                return View();
            }

            return RedirectToAction("index", "home");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("index", "home");
        }


        [HttpGet]
        //[Authorize(Roles="Member")]
        public async Task<IActionResult> Profile()
        {
            AppUser member = await _userManager.FindByNameAsync(User.Identity.Name);

            ProfileViewModel profileVM = new ProfileViewModel
            {
                Email = member.Email,
                FullName = member.Fullname,
                PhoneNumber = member.PhoneNumber,
                UserName = member.UserName
                
            };

            return View(profileVM);
        }
    }
}
