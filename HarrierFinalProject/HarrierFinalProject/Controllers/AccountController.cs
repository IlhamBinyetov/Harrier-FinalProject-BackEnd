﻿using HarrierFinalProject.Data;
using HarrierFinalProject.Data.Models;
using HarrierFinalProject.Services;
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
        private readonly IEmailService _emailService;

        public AccountController(AppDbContext context, UserManager <AppUser> userManager, SignInManager<AppUser> signInManager, IWebHostEnvironment env, IEmailService emailService )
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _env = env;
            _emailService = emailService;
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

            AppUser member = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == memberLoginVM.UserName );

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

            AppUser admin = null;

            admin = _userManager.Users.FirstOrDefault(x => x.UserName == memberLoginVM.UserName && x.IsAdmin);

            if (admin != null)
            {
                return RedirectToAction("index", "dashboard", new { area = "manage" });
            }
            else
            {
                return RedirectToAction("index", "home");
            }

            
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
                Image = member.Image,
                Orders = _context.Orders.Include(x => x.Car).ThenInclude(x=>x.Brand).Where(x => x.AppUserId == member.Id).ToList()
            };

            return View(profileVM);
        }


        [HttpPost]
        [Authorize(Roles = "Member")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Profile(ProfileViewModel profileVM)
        {
            TempData["Success"] = false;

            if (!ModelState.IsValid) return View();

            AppUser member = await _userManager.FindByNameAsync(User.Identity.Name);


            if (!string.IsNullOrWhiteSpace(profileVM.ConfirmNewPassword) && !string.IsNullOrWhiteSpace(profileVM.NewPassword))
            {
                var passwordChangeResult = await _userManager.ChangePasswordAsync(member, profileVM.CurrentPassword, profileVM.NewPassword);

                if (!passwordChangeResult.Succeeded)
                {
                    foreach (var item in passwordChangeResult.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    return View();
                }
            }

            if (member.Email != profileVM.Email && _userManager.Users.Any(x => x.NormalizedEmail == profileVM.Email.ToUpper()))
            {
                ModelState.AddModelError("Email", "This email has already been taken!");
                return View();
            }

            if (profileVM.FileImage != null)
            {
                if (profileVM.FileImage.ContentType != "image/png" && profileVM.FileImage.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "File type can be only jpeg,jpg or png!");
                    return View();
                }


                if (profileVM.FileImage.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "File size can not be more than 2MB!");
                    return View();
                }

                string fileName = profileVM.FileImage.FileName;
                if (fileName.Length > 64)
                {
                    fileName = fileName.Substring(fileName.Length - 64, 64);
                }

                string newFileName = Guid.NewGuid().ToString() + fileName;
                string path = Path.Combine(_env.WebRootPath, "assets/images", newFileName);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    profileVM.FileImage.CopyTo(stream);
                }

                member.Image = newFileName;
            }

           

            member.Fullname = profileVM.FullName;
            member.Email = profileVM.Email;
            member.PhoneNumber = profileVM.PhoneNumber;
            member.UserName = profileVM.UserName;


            _context.SaveChanges();


            var result = await _userManager.UpdateAsync(member);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }

                return View();
            }

            TempData["Success"] = true;
            return RedirectToAction("profile");
        }


        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }
         
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel forgotVM) 
        {
            AppUser user = await _userManager.FindByEmailAsync(forgotVM.Email);

            if (user == null)
            {
                ModelState.AddModelError("Email", "Email is not valid!");
                return View();
            }

            string token = await _userManager.GeneratePasswordResetTokenAsync(user);
            string callback = Url.Action("resetpassword", "account", new { token, email = user.Email}, Request.Scheme);
            string body = string.Empty;

            using (StreamReader reader = new StreamReader("wwwroot/templates/forgotPassword.html"))
            {
                body = reader.ReadToEnd();
            }


            body = body.Replace("{{url}}", callback);


            _emailService.Send(user.Email, "Reset Password", body);

                return RedirectToAction("login");
        }



        public async Task<IActionResult>  ResetPassword(string token, string email)
        {
            ResetPasswordViewModel resetPasswordVM = new ResetPasswordViewModel
            {
                Token = token,
                Email = email
            };

            return View(resetPasswordVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordVM)
        {
            if (!ModelState.IsValid) return View(resetPasswordVM);

            AppUser user = await _userManager.FindByEmailAsync(resetPasswordVM.Email);

            if (user == null) return RedirectToAction("index","Error");

            var resetResult = await _userManager.ResetPasswordAsync(user, resetPasswordVM.Token, resetPasswordVM.Password);

            if (!resetResult.Succeeded)
            {
                foreach (var item in resetResult.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View();
            }

            return RedirectToAction("login");
        }
    }
}
