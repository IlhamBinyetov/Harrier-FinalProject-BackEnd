using HarrierFinalProject.Data;
using HarrierFinalProject.Data.Models;
using HarrierFinalProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HarrierFinalProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IWebHostEnvironment _env;

        public AccountController(AppDbContext context, UserManager <AppUser> userManager, SignInManager<AppUser> signInManager, IWebHostEnvironment env )
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _env = env;
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
                IsAdmin = false,
                Image = memberRegisterVM.Image,
                ImageFile = memberRegisterVM.FileImage
               
            };



            if (member.ImageFile != null)
            {
                if (member.ImageFile.ContentType != "image/png" && member.ImageFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "File type can be only jpeg,jpg or png!");
                    return View();
                }


                if (member.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "File size can not be more than 2MB!");
                    return View();
                }

                string fileName = member.ImageFile.FileName;
                if (fileName.Length > 64)
                {
                    fileName = fileName.Substring(fileName.Length - 64, 64);
                }

                string newFileName = Guid.NewGuid().ToString() + fileName;
                string path = Path.Combine(_env.WebRootPath, "assets/images", newFileName);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    member.ImageFile.CopyTo(stream);
                }

                member.Image = newFileName;
            }

            _context.AppUsers.Add(member);
            _context.SaveChanges();



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
        [Authorize(Roles="Member")]
        public async Task<IActionResult> Profile()
        {
            AppUser member = await _userManager.FindByNameAsync(User.Identity.Name);

            ProfileViewModel profileVM = new ProfileViewModel
            {
                Email = member.Email,
                FullName = member.Fullname,
                PhoneNumber = member.PhoneNumber,
                UserName = member.UserName,
                Image = member.Image
                
                
            };

            return View(profileVM);
        }
    }
}
