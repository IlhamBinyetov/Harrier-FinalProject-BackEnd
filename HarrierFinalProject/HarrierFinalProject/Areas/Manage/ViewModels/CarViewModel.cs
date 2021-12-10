using HarrierFinalProject.Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrierFinalProject.Areas.Manage.ViewModels
{
    public class CarViewModel
    {
        public Car Car { get; set; }
        public List<Car> Cars { get; set; }
        public int BrandId { get; set; }
        public int ModelId { get; set; }
        public string Image { get; set; }
        public IFormFile ImageFile { get; set; }
        public decimal Price { get; set; }
        public DateTime DateOfProduct { get; set; }

        public string Name { get; set; }
    }
}
