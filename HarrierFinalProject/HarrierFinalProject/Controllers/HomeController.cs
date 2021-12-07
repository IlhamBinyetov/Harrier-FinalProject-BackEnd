using HarrierFinalProject.Data;
using HarrierFinalProject.Data.Models;
using HarrierFinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrierFinalProject.Controllers
{
    public class HomeController:Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(HomeViewModel homeVM)
        {      
            List<Car> cars = _context.Cars.Include(c => c.Brand)
                                          .Include(c=>c.Model)
                                          .Include(c => c.CarFeatures)
                                          .Include(c => c.CarImages)
                                          .Include(c => c.Gearbox)
                                          .Include(c => c.Transmission)
                                          .Include(c=>c.CarStatus) 
                                          .ToList();

            homeVM = new HomeViewModel()
            {
                Sliders = _context.Sliders.ToList(),
                CarTypes = _context.CarTypes.ToList(),
                Comments = _context.Comments.ToList(),
                Cars = cars,
                Partners = _context.Partners.ToList(),
                Blogs = _context.Blogs.ToList(),
                Advertisings = _context.Advertisings.ToList()
            
            };

            return View(homeVM);
        }

        public IActionResult AdvancedSearch()
        {
            return View();
        }


        public IActionResult AddToBasket(int id)
        {
            Car car = _context.Cars.Include(c=>c.Brand).Include(c => c.CarImages).FirstOrDefault(x => x.Id == id);

            List<BasketViewModel> favorites = new List<BasketViewModel>();
            string namesStr;
            BasketViewModel favorite = null;

            if (HttpContext.Request.Cookies["BasketCookie"] != null)
            {
                namesStr = HttpContext.Request.Cookies["BasketCookie"];
                favorites = JsonConvert.DeserializeObject<List<BasketViewModel>>(namesStr);
                favorite = favorites.FirstOrDefault(x => x.CarId == car.Id);
            }

            if (favorite == null)
            {
                favorite = new BasketViewModel
                {
                  CarName = car.Brand?.Name,
                  CarPrice = car.Price,
                  CarPosterImage = car.CarImages.FirstOrDefault(c=>c.IsPoster==true)?.Image
                };
                favorites.Add(favorite);

            }

            namesStr = JsonConvert.SerializeObject(favorites);
            HttpContext.Response.Cookies.Append("BasketCookie", namesStr);

            return PartialView("_BasketPartial", favorites);
        }
    }
}
