using HarrierFinalProject.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrierFinalProject.ViewModels
{
    public class CarViewModel
    {
        public List<Car> Cars { get; set; }
        public List<CarType> CarTypes { get; set; }
        public List<Advertising> Advertisings { get; set; }
        public Car Car { get; set; }
        public List<CarFeature> CarFeatures { get; set; }
        public List<CarColor> CarColors { get; set; }
        public List<CarStatus> CarStatuses { get; set; }
        public List<City> Cities  { get; set; }
        public List<CarImage> CarImages   { get; set; }
        public List<Gearbox> Gearboxes  { get; set; }
        public List<Transmission> Transmissions   { get; set; }
        public List<FuelType> FuelTypes   { get; set; }
        public List<Brand> Brands   { get; set; }
        public List<Model> Models   { get; set; }
        public List<Feature> Features { get; set; }

        public List<Car> RelatedCars { get; set; }


        public int CityId { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public bool isOrder { get; set; } = false;
        public CommentViewModel CommentViewModel { get; set; }

        public FilterViewModel FilterViewModel { get; set; }

    }
}
