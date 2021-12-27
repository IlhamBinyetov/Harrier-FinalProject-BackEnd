using HarrierFinalProject.Data;
using HarrierFinalProject.Data.Models;
using HarrierFinalProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrierFinalProject.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public ContactController(AppDbContext context, UserManager<AppUser> userManager )
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            ContactViewModel contactVM = new ContactViewModel()
            {
                Advertisings = _context.Advertisings.ToList()
                
            };


            return View(contactVM);
        }


        public IActionResult CreateContact(ContactViewModel contactVM)
        {   
            Contact contact = new Contact()
            {
                Name = contactVM.Name,
                Subject = contactVM.Subject,
                Message = contactVM.Messsage,
                Email = contactVM.Email
            };

            _context.Contacts.Add(contact);
            _context.SaveChanges();


            return RedirectToAction("Index", "Home");
        }
    }
}
