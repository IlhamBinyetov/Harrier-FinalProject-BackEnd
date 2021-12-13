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


        public IActionResult SubmitCar()
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





        //public IActionResult Deletefavorites(int id)
        //{
        //    Car car = _context.Cars.Include(x => x.CarImages).FirstOrDefault(x => x.Id == id);
        //    BasketViewModel favoriteItem = null;


        //    //AppUser member = null;

        //    //if (User.Identity.IsAuthenticated)
        //    //{
        //    //    member = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name && !x.IsAdmin);

        //    //}

        //    List<BasketViewModel> products = new List<BasketViewModel>();


        //    if (member == null)
        //    {
        //        string ProductStr = HttpContext.Request.Cookies["BasketCookie"];
        //        products = JsonConvert.DeserializeObject<List<BasketViewModel>>(ProductStr);

        //        favoriteItem = products.FirstOrDefault(x => x.CarId == id);



        //        products.Remove(favoriteItem);


        //        ProductStr = JsonConvert.SerializeObject(products);
        //        HttpContext.Response.Cookies.Append("BasketCookie", ProductStr);
        //    }
        //    else
        //    {
        //        FavoriteItem memberFavItem = _context.FavoriteItems.Include(x => x.Product).FirstOrDefault(x => x.AppUserId == member.Id && x.ProductId == id);



        //        _context.FavoriteItems.Remove(memberFavItem);



        //        _context.SaveChanges();

        //        products = _context.FavoriteItems.Include(x => x.Product).ThenInclude(bi => bi.ProductImages).Where(x => x.AppUserId == member.Id)
        //            .Select(x => new BasketViewModel
        //            {
        //                CarId = x.ProductId,
        //                Count = x.Count,
        //                CarName = x.Product.Name,
        //                CarPrice = (double)x.Product.Price,
        //                CarPosterImage = x.Car.CarImages.FirstOrDefault(b => b.IsPoster == true).Image
        //            }).ToList();
        //    }

        //    return PartialView("_BasketPartial", products);

        //}
    }
}
