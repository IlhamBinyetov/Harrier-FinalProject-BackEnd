using HarrierFinalProject.Data;
using HarrierFinalProject.Data.Models;
using HarrierFinalProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrierFinalProject.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public BlogController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index(BlogViewModel BlogVM)
        {
            List<Blog> blogs = _context.Blogs.ToList();
            List<Advertising> advertisings = _context.Advertisings.ToList();

            BlogVM = new BlogViewModel()
            {
                Blogs = blogs,
                Advertisings = advertisings
                
            };

            return View(BlogVM);
        }


        public IActionResult Detail(int id)
        {
            BlogDetailViewModel detailVM = new BlogDetailViewModel()
            {
                BLog = _context.Blogs.Include(x=>x.Comments).ThenInclude(x=>x.AppUser).FirstOrDefault(x=>x.Id == id),
                Advertisings = _context.Advertisings.ToList()
            }; 

            return View(detailVM);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlogComment(CarViewModel viewModel)
        {
            var member = await _userManager.GetUserAsync(User);

            CommentViewModel commentVM = viewModel.CommentViewModel;
            Comment comment = new Comment
            {
                PostDate = DateTime.Now,
                AppUserId = member.Id,
                BlogId = commentVM.BlogId,
                Description = commentVM.Description

            };

            _context.Comments.Add(comment);
            _context.SaveChanges();

            return RedirectToAction("Detail", "Blog",new { id = commentVM.BlogId});
        }
    }
}
