using HarrierFinalProject.Areas.Manage.Helpers;
using HarrierFinalProject.Areas.Manage.ViewModels;
using HarrierFinalProject.Data;
using HarrierFinalProject.Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HarrierFinalProject.Areas.Manage.Controllers
{
    [Area("manage")]
    //[Authorize(Roles = "SuperAdmin, Admin")]
    public class CarController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public CarController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int page=1, string search=null)
        {
            if (page <= 0)
            {
                page = 1;
            }

            var query = _context.Cars.Include(x => x.Brand).Include(x => x.Model).Include(c => c.CarImages).AsQueryable();

            ViewBag.CurrenSearch = search;

            if (!string.IsNullOrWhiteSpace(search))
                query = query.Where(x => x.Brand.Name.Contains(search) || x.Model.Name.Contains(search));

            List<Car> cars = query.Skip((page-1)*4).Take(4).ToList();

            ViewBag.TotalPage = Math.Ceiling(query.Count() / 4m);
            ViewBag.SelectedPage = page;

          
          

            


            CarViewModel carVM = new CarViewModel()
            {
                Cars = cars
            };


            return View(carVM);
        }

        [HttpGet]
        public IActionResult Create()
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


            CarViewModel carVM = new CarViewModel()
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


            return View(carVM);
        }

        [HttpPost]

        public IActionResult Create(CarViewModel carVM)
        {
            Car car = new Car()
            {
                BrandId = carVM.BrandId,
                ModelId = carVM.ModelId,
                TransmissionId = carVM.TransmissionId,
                GearboxId = carVM.GearboxId,
                CarColorId = carVM.CarColorId,
                CarTypeId = carVM.CarTypeId,
                FuelTypeId = carVM.FuelTypeId,
                ImageFiles = carVM.ImageFiles,
                PosterFile = carVM.PosterImage,
                CityId = carVM.CityId,
                CarStatusId = carVM.CarStatusId,
                Price = carVM.Price,
                DoorCount = carVM.DoorCount,
                DateOfProduct = carVM.DateOfProduct,
                Mileage = carVM.Mileage,
                Description = carVM.Description,
                MotorPower = carVM.MotorPower,
                HorsePower = carVM.HorsePower,
                CarImages = new List<CarImage>(),
                CarFeatures = new List<CarFeature>(),
                IsAccepted = true
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


            foreach (var featureId in carVM.CarFeatureIds)
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

            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Car car = _context.Cars.Include(c=>c.Model).Include(c => c.Brand)
                                                       .Include(c => c.Gearbox)
                                                       .Include(c => c.Transmission)
                                                       .Include(c => c.CarColor)
                                                       .Include(c => c.CarStatus)
                                                       .Include(c => c.CarFeatures)
                                                       .ThenInclude(c=>c.Feature)
                                                       .Include(c => c.FuelType)
                                                       .Include(c => c.CarImages)
                                                       .Include(c => c.City)
                                                       .FirstOrDefault(c => c.Id == id);

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
            List<int> carFeaturesIds = new List<int>();

            foreach (var item in car.CarFeatures)
            {
                carFeaturesIds.Add(item.FeatureId);
            }

            CarViewModel carVM = new CarViewModel()
            {
                Car = car,
                Price = car.Price,
                HorsePower = car.HorsePower,
                DoorCount = car.DoorCount,
                Mileage = car.Mileage,
                MotorPower = car.MotorPower,
                Description = car.Description,
                Cities = cities,
                Models = models,
                Brands = brands,
                Transmissions = transmissions,
                Gearboxes = gearboxes,
                CarColors = carColors,
                Features  = features,
                CarStatuses = carStatuses,
                FuelTypes = fuelTypes,
                CarTypes = carTypes,
                FeatureIds = carFeaturesIds,
                PosterImage = car.PosterFile,
                ImageFiles = car.ImageFiles
            };
            return View(carVM);
        }

        [HttpPost]
        public IActionResult Edit(int id, CarViewModel carVM)
        {

            if (!ModelState.IsValid) return View();

            Car existCar = _context.Cars.Include(x => x.CarImages).Include(x => x.CarFeatures).Include(c => c.Gearbox)
                                                                                              .Include(c => c.Transmission)
                                                                                              .Include(c => c.CarColor)
                                                                                              .Include(c => c.CarStatus)
                                                                                              .Include(c => c.Brand)
                                                                                              .Include(c => c.FuelType)
                                                                                              .Include(c => c.Model)
                                                                                              .Include(c => c.City).FirstOrDefault(x => x.Id == id );

            if (existCar == null) return NotFound();


            if (carVM.PosterImage != null)
            {
                if (carVM.PosterImage.ContentType != "image/png" && carVM.PosterImage.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("PosterImage", "File type can be only jpeg,jpg or png!");
                    return View();
                }

                if (carVM.PosterImage.Length > 2097152)
                {
                    ModelState.AddModelError("PosterImage", "File size can not be more than 2MB!");
                    return View();
                }


                CarImage poster = existCar.CarImages.FirstOrDefault(x => x.IsPoster == true);
                string newFileName = SaveImg.SaveImage(_env.WebRootPath, "assets/images", carVM.PosterImage);

                if (poster == null)
                {
                    poster = new CarImage
                    {
                        IsPoster = true,
                        Image = newFileName,
                        CarId = carVM.Car.Id
                    };

                    _context.CarImages.Add(poster);
                }
                else
                {
                    SaveImg.Delete(_env.WebRootPath, "assets/images", poster.Image);
                    poster.Image = newFileName;
                }
            }

            existCar.CarFeatures.RemoveAll((x => !carVM.FeatureIds.Contains(x.FeatureId)));

            if (carVM.FeatureIds != null)
            {
                foreach (var FeatureId in carVM.FeatureIds.Where(x => !existCar.CarFeatures.Any(bt => bt.FeatureId == x)))
                {
                    CarFeature carFeature = new CarFeature
                    {
                        FeatureId = FeatureId,
                        CarId = id
                    };
                    existCar.CarFeatures.Add(carFeature);
                }
            }

            
           // existCar.CarImages.RemoveAll(x => x.IsPoster == false );


            if (carVM.ImageFiles != null)
            {
                foreach (var file in carVM.ImageFiles)
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

                    existCar.CarImages.Add(image);
                }
            }


            existCar.BrandId = carVM.BrandId;
            existCar.ModelId = carVM.ModelId;
            existCar.Price = carVM.Price;
            existCar.Description = carVM.Description;
            existCar.DoorCount = carVM.DoorCount;
            existCar.DateOfProduct = carVM.DateOfProduct;
            existCar.HorsePower = carVM.HorsePower;
            existCar.Mileage = carVM.Mileage;
            existCar.MotorPower = carVM.MotorPower;
            existCar.CityId = carVM.CityId;
            existCar.TransmissionId = carVM.TransmissionId;
            existCar.GearboxId = carVM.GearboxId;
            existCar.CarColorId = carVM.CarColorId;
            existCar.CarStatusId = carVM.CarStatusId;
            existCar.CarTypeId = carVM.CarTypeId;
            existCar.FuelTypeId = carVM.FuelTypeId;

            _context.SaveChanges();


            return RedirectToAction("index");
        }

        public IActionResult DeleteFetch(int id)
        {
            Car car = _context.Cars.Include(x => x.CarImages).FirstOrDefault(x => x.Id == id);

            if (car == null) return Json(new { status = 404 });

            try
            {
                _context.Cars.Remove(car);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return Json(new { status = 500 });
            }

            List<CarImage> images = car.CarImages.Where(x => x.CarId == id).ToList();
            foreach (CarImage img in images)
            {
                string deletePath = Path.Combine(_env.WebRootPath, "assets/images", img.Image);
                if (System.IO.File.Exists(deletePath))
                {
                    System.IO.File.Delete(deletePath);
                }
            }
            return Json(new { status = 200 });
        }

        [HttpPost]
        [Produces("application/json")]
        public JsonResult GetModelByBrand([FromBody]CarViewModel viewModel)
        {
            List<Model> models = _context.Models.Where(m => m.BrandId == viewModel.BrandId).ToList();



            return Json(new { models });
        }


        [HttpPost]
        [Produces("application/json")]
        public JsonResult DeleteImageByCar([FromBody] CarViewModel viewModel)
        {
            bool isDelete = false;
           var image = _context.CarImages.FirstOrDefault(ci => ci.Id == viewModel.ImageId);

            if(image != null)
            {
                _context.CarImages.Remove(image); 
                _context.SaveChanges(); 
                isDelete = true;
            }
            
           

            return Json(isDelete);
        }



        [HttpPost]
        [Produces("application/json")]
        public JsonResult UpdateCarAccept([FromBody] CarViewModel viewModel)
        {
            bool isUpdate = false;
            var car = _context.Cars.FirstOrDefault(c => c.Id == viewModel.CarId);

            if (car != null)
            {
                car.IsAccepted = true; 
                _context.SaveChanges();
                isUpdate = true;
            } 

            return Json(new { isUpdate });
        }
    }
}
