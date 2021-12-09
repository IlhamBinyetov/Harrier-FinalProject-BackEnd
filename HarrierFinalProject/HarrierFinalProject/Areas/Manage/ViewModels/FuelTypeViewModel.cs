using HarrierFinalProject.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrierFinalProject.Areas.Manage.ViewModels
{
    public class FuelTypeViewModel
    {
        public  List<FuelType> FuelTypes { get; set; }
        public string Name { get; set; }
        public FuelType FuelType { get; set; }
    }
}
