using HarrierFinalProject.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrierFinalProject.ViewModels
{
    public class HomeViewModel
    {
        public List<Slider> Sliders { get; set; }
        public List<CarType> CarTypes { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Car> Cars { get; set; }
        public List<Partner> Partners { get; set; }
        public BlogViewModel BlogViewModel { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<Advertising> Advertisings { get; set; }
        public List<CarFeature> CarFeatures { get; set; }
       public List<Car> ExpensiveCars { get; set; }

        public FilterViewModel FilterVM { get; set; }

        public int BrandId { get; set; }
        public int ModelId { get; set; }
        public int FuelTypeId { get; set; }
        public int TransmissionId { get; set; }
        public int CarTypeId { get; set; }
        public int GearboxId { get; set; }

        public int HorsePower { get; set; }
        public string MotorPower { get; set; }
        public string Description { get; set; }
        public int DoorCount { get; set; }
        public string Mileage { get; set; }
        public decimal Price { get; set; }
       




        public Car Car { get; set; }
        public List<City> Cities { get; set; }
        public List<CarColor> CarColors { get; set; }
        public List<Brand> Brands { get; set; }
        public List<Model> Models { get; set; }
        public List<Transmission> Transmissions { get; set; }
        public List<Gearbox> Gearboxes { get; set; }
        public List<Feature> Features { get; set; }
        public List<CarStatus> CarStatuses { get; set; }
        
        public List<FuelType> FuelTypes { get; set; }
        public List<CarImage> CarImages { get; set; }

        public Brand Brand { get; set; }
        public List<int> FeatureIds { get; set; } = new List<int>();
    }
}
