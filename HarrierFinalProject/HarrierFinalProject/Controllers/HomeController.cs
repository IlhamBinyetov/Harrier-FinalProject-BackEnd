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
using System.IO;
using HarrierFinalProject.Areas.Manage.Helpers;
using Microsoft.AspNetCore.Hosting;

namespace HarrierFinalProject.Controllers
{
    public class HomeController:Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IWebHostEnvironment _env;

        public HomeController(AppDbContext context, UserManager<AppUser> userManager, IWebHostEnvironment env)
        {
            _context = context;
            _userManager = userManager;
            _env = env;
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


            var comments = _context.Comments.Include(x => x.AppUser).OrderByDescending(x => x.PostDate).Take(3).ToList();
            homeVM = new HomeViewModel()
            {
                Sliders = _context.Sliders.ToList(),
                CarTypes = _context.CarTypes.ToList(),
                Comments = comments,
                Cars = cars,
                Partners = _context.Partners.ToList(),
                Blogs = _context.Blogs.ToList(), 
                Advertisings = _context.Advertisings.ToList(),
                Brands = _context.Brands.ToList()
                
            };

            return View(homeVM);
        }

        public IActionResult AdvancedSearch(HomeViewModel homeVM)
        {

            homeVM = new HomeViewModel()
            {

                CarTypes = _context.CarTypes.ToList(),
                FuelTypes = _context.FuelTypes.ToList(),
                Brands = _context.Brands.ToList(),
                Models = _context.Models.ToList(),
                Gearboxes = _context.Gearboxes.ToList(),
                Cities = _context.Cities.ToList(),
                CarColors = _context.CarColors.ToList(),
                CarFeatures = _context.CarFeatures.ToList(),
                Transmissions = _context.Transmissions.ToList(),
                Features = _context.Features.ToList()


            };
            return View(homeVM);
        }

        [HttpGet]
        public IActionResult SubmitCar()
        {
          

            List<City> cities = _context.Cities.ToList();
            List<Model> models = _context.Models.ToList();
            List<Brand> brands = _context.Brands.ToList();
            List<Transmission> transmissions = _context.Transmissions.ToList();
            List<Gearbox> gearboxes = _context.Gearboxes.ToList();
            List<CarColor> carColors = _context.CarColors.ToList();
            List<Feature> features = _context.Features.ToList();
            List<CarStatus> carStatuses = _context.CarStatuses.ToList();
            List<FuelType> fuelTypes = _context.FuelTypes.ToList();
            List<CarType> carTypes = _context.CarTypes.ToList();
            List<CarImage> carImages = _context.CarImages.ToList();



            SubmitViewModel submitVM = new SubmitViewModel()
            {
                Cities = cities,
                Models = models,
                Brands = brands,
                Transmissions = transmissions,
                Gearboxes = gearboxes,
                CarColors = carColors,
                Features = features,
                CarStatuses = carStatuses,
                FuelTypes = fuelTypes,
                CarTypes = carTypes,
                CarImages = carImages

            };

          
            return View(submitVM);
        }

        [HttpPost]
        public IActionResult SubmitCar(SubmitViewModel submitVM)
        {
            TempData["Success"] = false;

            Car car = new Car()
            {
                BrandId = submitVM.BrandId,
                ModelId = submitVM.ModelId,
                TransmissionId = submitVM.TransmissionId,
                GearboxId = submitVM.GearboxId,
                CarColorId = submitVM.CarColorId,
                CarTypeId = submitVM.CarTypeId,
                FuelTypeId = submitVM.FuelTypeId,
                ImageFiles = submitVM.ImageFiles,
                PosterFile = submitVM.PosterImage,
                CityId = submitVM.CityId,
                CarStatusId = submitVM.CarStatusId,
                Price = submitVM.Price,
                DoorCount = submitVM.DoorCount,
                DateOfProduct = submitVM.DateOfProduct,
                Mileage = submitVM.Mileage,
                Description = submitVM.Description,
                MotorPower = submitVM.MotorPower,
                HorsePower = submitVM.HorsePower,
                CarImages = new List<CarImage>(),
                CarFeatures = new List<CarFeature>(),
                IsAccepted = false
            };



            if (car.PosterFile == null)
            {
                ModelState.AddModelError("PosterFile", "Poster file is required");
            }
            else
            {
                if (car.PosterFile.ContentType != "image/png" && car.PosterFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("PosterFile", "File type can be only jpeg,jpg or png!");
                    return View();
                }

                if (car.PosterFile.Length > 2097152)
                {
                    ModelState.AddModelError("PosterFile", "File size can not be more than 2MB!");
                    return View();
                }

                string newFileName = Guid.NewGuid().ToString() + car.PosterFile.FileName;
                string path = Path.Combine(_env.WebRootPath, "assets/images", newFileName);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    car.PosterFile.CopyTo(stream);
                }

                CarImage poster = new CarImage
                {
                    Image = newFileName,
                    IsPoster = true,
                };

                car.CarImages.Add(poster);
            }



            if (car.ImageFiles != null)
            {
                foreach (var file in car.ImageFiles)
                {
                    if (file.ContentType != "image/png" && file.ContentType != "image/jpeg")
                    {
                        continue;
                    }

                    if (file.Length > 2097152)
                    {
                        continue;
                    }

                    CarImage image = new CarImage
                    {
                        IsPoster = false,
                        Image = SaveImg.SaveImage(_env.WebRootPath, "assets/images", file)
                    };

                    car.CarImages.Add(image);
                }
            }


            foreach (var featureId in submitVM.CarFeatureIds)
            {
                CarFeature carFeature = new CarFeature
                {
                    Car = car,
                    FeatureId = featureId
                };
                car.CarFeatures.Add(carFeature);
            }

            _context.Cars.Add(car);
            _context.SaveChanges();

            TempData["Success"] = true;
            return RedirectToAction("Index");


        }





        public IActionResult AddCar(int id)
        {
            Car car = _context.Cars.Include(x => x.CarImages).Include(x => x.Brand).FirstOrDefault(x => x.Id == id);

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





        [HttpPost]
        [Produces("application/json")]
        public JsonResult GetModelByBrand([FromBody] SubmitViewModel viewModel)
        {
            List<Model> models = _context.Models.Where(m => m.BrandId == viewModel.BrandId).ToList();
             
            return Json(new { models });
        }

    }
        
}

