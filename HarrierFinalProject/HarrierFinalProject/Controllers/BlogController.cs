using HarrierFinalProject.Data;
using HarrierFinalProject.Data.Models;
using HarrierFinalProject.ViewModels;
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

        public BlogController(AppDbContext context)
        {
            _context = context;
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
                BLog = _context.Blogs.Include(x=>x.Comments).FirstOrDefault(x=>x.Id == id),
                Advertisings = _context.Advertisings.ToList()
            }; 

            return View(detailVM);
        }
    }
}
