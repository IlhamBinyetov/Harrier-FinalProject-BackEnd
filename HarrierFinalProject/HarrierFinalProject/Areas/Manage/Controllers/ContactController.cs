using HarrierFinalProject.Areas.Manage.ViewModels;
using HarrierFinalProject.Data;
using HarrierFinalProject.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrierFinalProject.Areas.Manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public ContactController(AppDbContext context, UserManager<AppUser> userManager  )
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            List<Contact> contacts = _context.Contacts.ToList();

            AppUser member = _userManager.Users.FirstOrDefault(x => x.IsAdmin == false );

            ContactsViewModel contactsVM = new ContactsViewModel()
            {
                Contacts = contacts,
                AppUser = member

            };

            return View(contactsVM);
        }

        public IActionResult DeleteFetch(int id)
        {
            Contact contact = _context.Contacts.FirstOrDefault(x => x.Id == id);

            if (contact == null) return Json(new { status = 404 });

            try
            {
                _context.Contacts.Remove(contact);
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
