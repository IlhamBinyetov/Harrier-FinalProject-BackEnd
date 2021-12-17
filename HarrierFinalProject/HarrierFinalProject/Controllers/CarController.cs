using HarrierFinalProject.Data;
using HarrierFinalProject.Data.Models;
using HarrierFinalProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrierFinalProject.Controllers
{
    public class CarController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public CarController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            List<Car> cars = _context.Cars.Include(c => c.Brand)
                                        .Include(c => c.Model)
                                        .Include(c => c.CarImages)
                                        .ToList();


            CarViewModel carVM  = new CarViewModel()
            {
                Cars = cars,
                Advertisings = _context.Advertisings.ToList(),
                CarTypes = _context.CarTypes.ToList()

            };


            ViewBag.PopularCars = _context.Cars.Include(c => c.Brand)
                                        .Include(c => c.Model)
                                        .Include(c => c.CarImages)
                                        .Take(5)
                                        .ToList();


            return View(carVM);
        }

        public IActionResult Detail(int id)
        {


            ViewBag.RelatedCars = _context.Cars.Include(c => c.Brand)
                                        .Include(c => c.Model)
                                        .Include(c => c.CarImages)
                                        .Take(4)
                                        .ToList();

            ViewBag.Advertisements = _context.Advertisings.ToList();


            Car car = _context.Cars.Include(c => c.CarImages)
                                   .Include(c => c.Model)
                                   .Include(c => c.CarStatus)
                                   .Include(c => c.CarType)
                                   .Include(c => c.CarColor)
                                   .Include(c=> c.CarFeatures)
                                   .ThenInclude(c => c.Feature)
                                   .Include(c => c.Transmission)
                                   .Include(c => c.Gearbox)
                                   .Include(c => c.Brand)
                                   .Include(c => c.City)
                                   .Include(c => c.FuelType)
                                   .Include(c=> c.Comments)
                                   .FirstOrDefault(x => x.Id == id);



            return View(car);
        }


        public IActionResult AddToBasket(int id)
        {
            Car car = _context.Cars.Include(x => x.CarImages).Include(x=>x.Brand).FirstOrDefault(x => x.Id == id);
            BasketViewModel favoriteItem = null;

            if (car == null) return NotFound();

            AppUser member = null;

            if (User.Identity.IsAuthenticated)
            {
                member = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name && !x.IsAdmin);
            }
            List<BasketViewModel> cars = new List<BasketViewModel>();
            if (member == null)
            {
                string ProductStr;

                if (HttpContext.Request.Cookies["BasketCookie"] != null)
                {
                    ProductStr = HttpContext.Request.Cookies["BasketCookie"];
                    cars = JsonConvert.DeserializeObject<List<BasketViewModel>>(ProductStr);

                    favoriteItem = cars.FirstOrDefault(x => x.CarId == id);
                }
                if (favoriteItem == null)
                {
                    favoriteItem = new BasketViewModel
                    {
                        CarId = car.Id,
                        CarName = car.Brand.Name,
                        CarPosterImage = car.CarImages.FirstOrDefault(x => x.IsPoster == true).Image,
                        CarPrice = (decimal)car.Price,
                        Count = 1
                    };
                    cars.Add(favoriteItem);
                }
                else
                {
                    favoriteItem.Count++;
                }
                ProductStr = JsonConvert.SerializeObject(cars);
                HttpContext.Response.Cookies.Append("BasketCookie", ProductStr);
            }
            else
            {
                BasketItem memberFavItem = _context.BasketItems.FirstOrDefault(x => x.AppUserId == member.Id && x.CarId == id);

                if (memberFavItem == null)
                {
                    memberFavItem = new BasketItem
                    {
                        AppUserId = member.Id,
                        CarId = id,
                        Count = 1
                    };
                    _context.BasketItems.Add(memberFavItem);
                }

                _context.SaveChanges();
                cars = _context.BasketItems.Where(x=>x.AppUserId==member.Id).Select(x =>
                 new BasketViewModel
                 {
                     CarId = x.CarId,
                     Count = x.Count,
                     CarName = x.Car.Brand.Name,
                     CarPrice = (decimal)x.Car.Price,
                     CarPosterImage = x.Car.CarImages
                               .FirstOrDefault(bi => bi.IsPoster == true).Image
                 }).ToList();
            }
            return PartialView("_BasketPartial", cars);
        }



        public IActionResult Deletefavorites(int id)
        {
            Car car = _context.Cars.Include(x => x.CarImages).Include(x=>x.Brand).FirstOrDefault(x => x.Id == id);
            BasketViewModel basketItem = null;


            AppUser member = null;

            if (User.Identity.IsAuthenticated)
            {
                member = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name && !x.IsAdmin);

            }

            List<BasketViewModel> cars = new List<BasketViewModel>();


            if (member == null)
            {
                string ProductStr = HttpContext.Request.Cookies["BasketCookie"];
                cars = JsonConvert.DeserializeObject<List<BasketViewModel>>(ProductStr);

                basketItem = cars.FirstOrDefault(x => x.CarId == id);



                cars.Remove(basketItem);


                ProductStr = JsonConvert.SerializeObject(cars);
                HttpContext.Response.Cookies.Append("BasketCookie", ProductStr);
            }
            else
            {


                BasketItem memberFavItem = _context.BasketItems.Include(x => x.Car).FirstOrDefault(x => x.AppUserId == member.Id && x.CarId == id);

                _context.BasketItems.Remove(memberFavItem);



                _context.SaveChanges();

                cars = _context.BasketItems.Include(x => x.Car).ThenInclude(bi => bi.CarImages).Where(x => x.AppUserId == member.Id)
                    .Select(x => new BasketViewModel
                    {
                        CarId = x.CarId,
                        Count = x.Count,
                        CarName = x.Car.Brand.Name,
                        CarPrice = (decimal)x.Car.Price,
                        CarPosterImage = x.Car.CarImages.FirstOrDefault(b => b.IsPoster == true).Image
                    }).ToList();
            }

            return PartialView("_BasketPartial", cars);

        }


        public IActionResult Cart()
        {
            return View();
        }


        public IActionResult Checkout()
        {
            return View();
        }
    }
}
