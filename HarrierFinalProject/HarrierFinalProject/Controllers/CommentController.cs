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
    public class CommentController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public CommentController(AppDbContext context, UserManager<AppUser> userManager )
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CarViewModel viewModel)
        {
            var member = await _userManager.GetUserAsync(User);

            CommentViewModel commentVM = viewModel.CommentViewModel;
            Comment comment = new Comment
            {
                 PostDate = DateTime.Now,
                 AppUserId = member.Id,
                 CarId = commentVM.CarId,
                 Description = commentVM.Description

            };

            _context.Comments.Add(comment);
            _context.SaveChanges();

            return RedirectToAction("Detail","Car", new { id = commentVM.CarId});
        }
    }
}
