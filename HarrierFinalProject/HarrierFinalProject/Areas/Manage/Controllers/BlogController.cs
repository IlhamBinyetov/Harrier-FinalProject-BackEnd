using HarrierFinalProject.Areas.Manage.ViewModels;
using HarrierFinalProject.Data;
using HarrierFinalProject.Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HarrierFinalProject.Areas.Manage.Controllers
{
    [Area("manage")]
    public class BlogController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly AppDbContext _context;

        public BlogController(AppDbContext context, IWebHostEnvironment env)
        {
            _env = env;
            _context = context;
        }
        public IActionResult Index()
        {
            List<Blog> blogs = _context.Blogs.ToList();

            BlogViewModel blogVM = new BlogViewModel()
            {
                Blogs = blogs
            };

            return View(blogVM);
        }

        [HttpGet]
        public IActionResult Create()
        {
            List<Blog> blogs = _context.Blogs.ToList();


            BlogViewModel blogVM = new BlogViewModel()
            {
                Blogs = blogs
            };

            return View(blogVM);

        }

        [HttpPost]
        public IActionResult Create(BlogViewModel blogVM)
        {
            Blog blog = new Blog()
            {
                Name = blogVM.Name,
                Image = blogVM.Image,
                Description = blogVM.Description,
                PostDate = blogVM.PostDate,
                PostedBy = blogVM.PostedBy,
                BlogImage = blogVM.ImageFile
            };


            if (blog.BlogImage != null)
            {
                if (blog.BlogImage.ContentType != "image/png" && blog.BlogImage.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("BlogImage", "File type can be only jpeg,jpg or png!");
                    return View();
                }


                if (blog.BlogImage.Length > 2097152)
                {
                    ModelState.AddModelError("BlogImage", "File size can not be more than 2MB!");
                    return View();
                }

                string fileName = blog.BlogImage.FileName;
                if (fileName.Length > 64)
                {
                    fileName = fileName.Substring(fileName.Length - 64, 64);
                }

                string newFileName = Guid.NewGuid().ToString() + fileName;
                string path = Path.Combine(_env.WebRootPath, "assets/images", newFileName);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    blog.BlogImage.CopyTo(stream);
                }

                blog.Image = newFileName;
            }

            _context.Blogs.Add(blog
                );
            _context.SaveChanges();

            return RedirectToAction("index");
        }


        [HttpGet]

        public IActionResult Edit(int id)
        {
            Blog blog = _context.Blogs.FirstOrDefault(c => c.Id == id);

            BlogViewModel blogVM = new BlogViewModel
            {
                Blog = blog

            };

            if (blog == null) return NotFound();

            return View(blogVM);
        }

        [HttpPost]
        public IActionResult Edit(int id, BlogViewModel blogVM)
        {

            if (blogVM.ImageFile == null) return View();


            if (!ModelState.IsValid) return View();


            Blog existBlog = _context.Blogs.FirstOrDefault(x => x.Id == id);

            if (existBlog == null) return NotFound();


            string newFileName = null;

            if (blogVM.ImageFile != null)
            {
                if (blogVM.ImageFile.ContentType != "image/png" && blogVM.ImageFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "File type can be only jpeg,jpg or png!");
                    return View();
                }


                if (blogVM.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "File size can not be more than 2MB!");
                    return View();
                }

                newFileName = Guid.NewGuid().ToString() + blogVM.ImageFile.FileName;
                string path = Path.Combine(_env.WebRootPath, "assets/images", newFileName);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    blogVM.ImageFile.CopyTo(stream);
                }

            }



            if (newFileName != null || blogVM.Image == null)
            {
                if (existBlog.Image != null)
                {
                    string deletePath = Path.Combine(_env.WebRootPath, "assets/images", existBlog.Image);

                    if (System.IO.File.Exists(deletePath))
                    {
                        System.IO.File.Delete(deletePath);
                    }
                }

                existBlog.Image = newFileName;
            }

            existBlog.Image = newFileName;
            existBlog.BlogImage = blogVM.ImageFile;
            existBlog.Name = blogVM.Name;
            existBlog.Description = blogVM.Description;
            existBlog.PostDate = blogVM.PostDate;
            existBlog.PostedBy = blogVM.PostedBy;

            _context.SaveChanges();

            return RedirectToAction("index");
        }


        public IActionResult DeleteFetch(int id)
        {
            Blog blog = _context.Blogs.FirstOrDefault(x => x.Id == id);

            if (blog == null) return Json(new { status = 404 });

            try
            {
                _context.Blogs.Remove(blog);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return Json(new { status = 500 });
            }
            string deletePath = Path.Combine(_env.WebRootPath, "assets/images", blog.Image);

            if (System.IO.File.Exists(deletePath))
            {
                System.IO.File.Delete(deletePath);
            }

            return Json(new { status = 200 });


        }
    }
}
