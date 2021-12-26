using HarrierFinalProject.Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrierFinalProject.ViewModels
{
    public class SubmitViewModel
    {

        public Car Car { get; set; }
        public List<Car> Cars { get; set; }
        public int BrandId { get; set; }
        public int ModelId { get; set; }
        public int FuelTypeId { get; set; }
        public int TransmissionId { get; set; }
        public int CarTypeId { get; set; }
        public int GearboxId { get; set; }
        public string Image { get; set; }
        public IFormFile PosterImage { get; set; }
        public List<IFormFile> ImageFiles { get; set; }
        public int CarColorId { get; set; }
        public List<int> CarFeatureIds { get; set; }
        public int CityId { get; set; }
        public int CarStatusId { get; set; }

        public int HorsePower { get; set; }
        public string MotorPower { get; set; }
        public string Description { get; set; }
        public int DoorCount { get; set; }
        public string Mileage { get; set; }
        public decimal Price { get; set; }
        public DateTime DateOfProduct { get; set; }



        public List<City> Cities { get; set; }
        public List<CarColor> CarColors { get; set; }
        public List<Brand> Brands { get; set; }
        public List<Model> Models { get; set; }
        public List<Transmission> Transmissions { get; set; }
        public List<Gearbox> Gearboxes { get; set; }
        public List<Feature> Features { get; set; }
        public List<CarStatus> CarStatuses { get; set; }
        public List<CarType> CarTypes { get; set; }
        public List<FuelType> FuelTypes { get; set; }
        public List<CarImage> CarImages { get; set; }

        public Brand Brand { get; set; }
        public List<int> FeatureIds { get; set; } = new List<int>();

      
    }
}
