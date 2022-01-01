using HarrierFinalProject.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HarrierFinalProject.ViewModels
{
    public class FilterViewModel
    {
        public Car Car { get; set; }
        public int? BrandId { get; set; }
        public int? ModelId { get; set; }
        public decimal? Price { get; set; }

        [DataType(DataType.Date)]        
        public DateTime? DateOfProduct { get; set; }
        public string Mileage { get; set; }
        public int? CityId { get; set; }
        public int? FuelTypeId { get; set; }
        public int? CarTypeId { get; set; }
        public int? TransmissionId { get; set; }
        public int? CarColorId { get; set; }
        public int? GearboxId { get; set; }
        public string MileageFrom { get; set; }
        public string MileageTo { get; set; }
        public DateTime? DateOfProductFrom { get; set; }
        public DateTime? DateOfProductTo { get; set; }
        public decimal? PriceFrom { get; set; }
        public decimal? PriceTo { get; set; }
        public string MotorPowerFrom { get; set; }
        public string MotorPowerTo { get; set; }
        public List<Car> Cars { get; set; }
        public int? SortId { get; set; }

        public int? CarSituationId { get; set; }
        public List<int> FeatureIds { get; set; } = new List<int>();

    }
}
