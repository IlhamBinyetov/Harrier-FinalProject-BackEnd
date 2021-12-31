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
        public IActionResult Index(FilterViewModel filterVM, int page=1)
        {
            if (page <= 0)
            {
                page = 1;
            }

            var query = _context.Cars.Include(x=>x.AppUser).Include(x => x.Brand).Include(x => x.Model).Include(c => c.CarImages).Where(c=>c.CarSituationId==1 && c.IsAccepted==true).AsQueryable();
            List<Car> cars = query.ToList();




            if (filterVM != null)
            {
                if (filterVM.BrandId != null)
                {
                    cars =  cars.Where(x => x.BrandId == filterVM.BrandId).ToList();
                }
                if (filterVM.ModelId != null)
                {
                    cars = cars.Where(x => x.ModelId == filterVM.ModelId).ToList();
                }
                if(filterVM.Mileage != null)
                {
                    cars = cars.Where(x => Int32.Parse(x.Mileage) <= Int32.Parse(filterVM.Mileage)).ToList();
                }
                if(filterVM.Price != null)
                {
                    cars = cars.Where(x => x.Price <= filterVM.Price).ToList();
                }
                if(filterVM.DateOfProduct != null)
                {
                    cars = cars.Where(x => x.DateOfProduct >= filterVM.DateOfProduct).ToList();
                }
                if (filterVM.CityId != null)
                {
                    cars = cars.Where(x => x.CityId == filterVM.CityId).ToList();
                }
                if (filterVM.FuelTypeId != null)
                {
                    cars = cars.Where(x => x.FuelTypeId == filterVM.FuelTypeId).ToList();
                }
                if (filterVM.TransmissionId != null)
                {
                    cars = cars.Where(x => x.TransmissionId == filterVM.TransmissionId).ToList();
                }
                if (filterVM.GearboxId != null)
                {
                    cars = cars.Where(x => x.GearboxId == filterVM.GearboxId).ToList();
                }
                if (filterVM.CarColorId != null)
                {
                    cars = cars.Where(x => x.CarColorId == filterVM.CarColorId).ToList();
                }
                if (filterVM.CarTypeId != null)
                {
                    cars = cars.Where(x => x.CarTypeId == filterVM.CarTypeId).ToList();
                }
                if (filterVM.MileageFrom != null)
                {
                    cars = cars.Where(x => Int32.Parse(x.Mileage) >= Int32.Parse(filterVM.MileageFrom)).ToList();
                }
                if (filterVM.MileageTo != null)
                {
                    cars = cars.Where(x => Int32.Parse(x.Mileage) <= Int32.Parse(filterVM.MileageTo)).ToList();
                }
                if (filterVM.DateOfProductFrom != null)
                {
                    cars = cars.Where(x =>x.DateOfProduct >= filterVM.DateOfProductFrom).ToList();
                }
                if (filterVM.DateOfProductTo != null)
                {
                    cars = cars.Where(x =>x.DateOfProduct <= filterVM.DateOfProductTo).ToList();
                }
                if (filterVM.PriceFrom != null)
                {
                    cars = cars.Where(x => x.Price >= filterVM.PriceFrom).ToList();
                }
                if (filterVM.PriceTo != null)
                {
                    cars = cars.Where(x => x.Price <= filterVM.PriceTo).ToList();
                }
                if (filterVM.MotorPowerFrom != null)
                {
                    cars = cars.Where(x => Int32.Parse(x.MotorPower) >= Int32.Parse(filterVM.MotorPowerFrom)).ToList();
                }
                if (filterVM.MotorPowerTo != null)
                {
                    cars = cars.Where(x => Int32.Parse(x.MotorPower) <= Int32.Parse(filterVM.MotorPowerTo)).ToList();
                }

                if (filterVM.SortId != null)
                {
                    if (filterVM.SortId==0)
                    {
                        cars = cars.OrderByDescending(x => x.DateOfProduct).ToList();
                    }
                    if (filterVM.SortId == 1)
                    {
                        cars = cars.OrderBy(x => x.Price).ToList();
                    }
                    if (filterVM.SortId == 2)
                    {
                        cars = cars.OrderByDescending(x => x.Price).ToList();
                    }
                }
                if (filterVM.CarSituationId != null)
                {
                    if (filterVM.CarSituationId == 1)
                    {
                        cars = cars.Where(x => x.CarStatusId == 2).ToList();
                    }
                    if (filterVM.CarSituationId == 2)
                    {
                        cars = cars.Where(x => x.CarStatusId == 1).ToList();
                    }
                }
                if (filterVM.FeatureIds != null)
                {
                    
                    
                }

            } 

            ViewBag.TotalPage = Math.Ceiling(cars.Count() / 5m);
            ViewBag.SelectedPage = page;
            cars = cars.Skip((page - 1) * 5).Take(5).ToList();

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

        public async Task<IActionResult> Detail(int id)
        {


            ViewBag.RelatedCars = _context.Cars.Include(c => c.Brand)
                                        .Include(c => c.Model)
                                        .Include(c => c.CarImages)
                                        .Take(4)
                                        .ToList();

            ViewBag.Advertisements = _context.Advertisings.ToList();
            CarViewModel carVM = new CarViewModel();


            AppUser member = await _userManager.GetUserAsync(User);

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

            carVM.Car = car;
            if (member != null)
            {
                var userOrder = _context.Orders.FirstOrDefault(o => o.AppUserId == member.Id && o.CarId == car.Id);
                if (userOrder != null)
                {
                    carVM.isOrder = true;
                }
            }
          


            return View(carVM);
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


            List<BasketViewModel> basketVM = new List<BasketViewModel>();
            CarViewModel carVm = new CarViewModel()
            {
                Cars = new List<Car>()
            };

            AppUser member = null;
            if (User.Identity.IsAuthenticated)
            {
                member = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name && !x.IsAdmin);
            }

            if (member == null)
            {
                var CarStr = HttpContext.Request.Cookies["BasketCookie"];
                if (!string.IsNullOrWhiteSpace(CarStr))
                {
                    basketVM = JsonConvert.DeserializeObject<List<BasketViewModel>>(CarStr);

                   

                    foreach (var item in basketVM)
                    {
                        Car car = _context.Cars.Include(c=>c.Brand).Include(x => x.CarImages).FirstOrDefault(x => x.Id == item.CarId);
                        if (car != null)
                        {
                            carVm.Cars.Add(car); 
                        }
                    }
                }
            }
            else
            {
                carVm.Cars = _context.BasketItems.Include(x => x.Car)
                                                            .ThenInclude(x => x.Brand)
                                                            .Include(x => x.Car)
                                                            .ThenInclude(x => x.CarImages)
                                                            .Where(x => x.AppUserId == member.Id)
                                                  .Select(x => new Car
                                                  {
                                                      Id = x.Car.Id,
                                                      Brand = x.Car.Brand,
                                                      Model = x.Car.Model,
                                                      Price = x.Car.Price,
                                                      CarImages = x.Car.CarImages
                                                  }).ToList();
            }

            return View(carVm);
        }


        public IActionResult Checkout()
        {
            List<City> cities = _context.Cities.ToList();

            List<BasketViewModel> basketVM = new List<BasketViewModel>();

            AppUser member = null;
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("login", "account");  
            }
            else
            {
                member = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name && !x.IsAdmin);
            }


            CarViewModel carVm = new CarViewModel();

                 carVm.Cars = _context.BasketItems.Include(x => x.Car)
                                                            .ThenInclude(x => x.Brand)
                                                            .Include(x => x.Car)
                                                            .ThenInclude(x => x.CarImages)
                                                            .Include(x => x.Car)
                                                            .ThenInclude(x => x.City)
                                                            .Where(x => x.AppUserId == member.Id)
                                                  .Select(x => new Car
                                                  {
                                                      Brand = x.Car.Brand,
                                                      Model = x.Car.Model,
                                                      Price = x.Car.Price,
                                                      CarImages = x.Car.CarImages,
                                                      City = x.Car.City
                                                  }).ToList();

            carVm.Cities = cities;

            return View(carVm);
        }
    }
}
