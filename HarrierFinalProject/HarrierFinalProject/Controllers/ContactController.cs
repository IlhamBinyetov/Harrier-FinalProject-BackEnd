using HarrierFinalProject.Data;
using HarrierFinalProject.ViewModels;
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

        public ContactController(AppDbContext context )
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ContactViewModel contactVM = new ContactViewModel()
            {
                Advertisings = _context.Advertisings.ToList(),
                Contact = _context.Contacts.FirstOrDefault()
            };


            return View(contactVM);
        }
    }
}
