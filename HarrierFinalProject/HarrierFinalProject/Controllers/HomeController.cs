using HarrierFinalProject.Data;
using HarrierFinalProject.Data.Models;
using HarrierFinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace HarrierFinalProject.Controllers
{
    public class HomeController:Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public HomeController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
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


        public IActionResult SubmitCar()
        {
            return View();
        }
        
        //public IActionResult AddToBasket(int id)
        //{
        //    Car car = _context.Cars.Include(c=>c.Brand).Include(c => c.CarImages).FirstOrDefault(x => x.Id == id);
        //    BasketViewModel favorite = null;

        //    List<BasketViewModel> favorites = new List<BasketViewModel>();


        //    if (car == null) return NotFound();

           
        //    AppUser member = null;

        //    if (User.Identity.IsAuthenticated)
        //    {
        //        member = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name && !x.IsAdmin);
        //    }

        //    if (member == null)
        //    {

        //        List<BasketViewModel> favorites = new List<BasketViewModel>();
        //        string namesStr;



        //        if (HttpContext.Request.Cookies["BasketCookie"] != null)
        //        {
        //            namesStr = HttpContext.Request.Cookies["BasketCookie"];
        //            favorites = JsonConvert.DeserializeObject<List<BasketViewModel>>(namesStr);
        //            favorite = favorites.FirstOrDefault(x => x.CarId == car.Id);
        //        }

        //        if (favorite == null)
        //        {
        //            favorite = new BasketViewModel
        //            {
        //                CarName = car.Brand?.Name,
        //                CarPrice = car.Price,
        //                CarPosterImage = car.CarImages.FirstOrDefault(c => c.IsPoster == true)?.Image
        //            };
        //            favorites.Add(favorite);

        //        }

        //        namesStr = JsonConvert.SerializeObject(favorites);
        //        HttpContext.Response.Cookies.Append("BasketCookie", namesStr);  


        //    }
        //    else
        //    {
        //        BasketItem memberBasketItem = _context.BasketItems.FirstOrDefault(x => x.AppUserId == member.Id && x.CarId == id);

        //        if (memberBasketItem == null)
        //        {
        //            memberBasketItem = new BasketItem
        //            {
        //                AppUserId = member.Id,
        //                CarId = id
        //            };
        //            _context.BasketItems.Add(memberBasketItem);
        //        }
        //        _context.SaveChanges();
        //    }

        //    return PartialView("_BasketPartial", favorites);
        //}


        public IActionResult AddCar(int id)
        {
            Car car = _context.Cars.Include(x => x.CarImages).Include(x=>x.Brand).FirstOrDefault(x => x.Id == id);

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
                    Count = 1,
                    CarId = car.Id,
                    CarPosterImage = car.CarImages.FirstOrDefault(x => x.IsPoster)?.Image,
                    CarName = car.Brand.Name,
                    CarPrice = (decimal)car.Price
                };
                favorites.Add(favorite);

            }
            else
            {
                favorite.Count++;
            }

            namesStr = JsonConvert.SerializeObject(favorites);
            HttpContext.Response.Cookies.Append("BasketCookie", namesStr);


            return PartialView("_BasketPartial", favorites);

           
        }



    }
}
