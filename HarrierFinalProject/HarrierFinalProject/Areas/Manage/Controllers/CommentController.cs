using HarrierFinalProject.Areas.Manage.ViewModels;
using HarrierFinalProject.Data;
using HarrierFinalProject.Data.Models;
using Microsoft.AspNetCore.Authorization;
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
            List<Comment> comments = _context.Comments.Include(x=>x.AppUser).ToList();

            CommentsViewModel commentVM = new CommentsViewModel()
            {
                Comments = comments
            };

            return View(commentVM);
        }


        public IActionResult DeleteFetch(int id)
        {
            Comment comment = _context.Comments.FirstOrDefault(x => x.Id == id);

            if (comment == null) return Json(new { status = 404 });

            try
            {
                _context.Comments.Remove(comment);
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
