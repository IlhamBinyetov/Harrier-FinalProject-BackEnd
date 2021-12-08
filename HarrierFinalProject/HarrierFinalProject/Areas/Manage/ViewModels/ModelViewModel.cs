using HarrierFinalProject.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrierFinalProject.Areas.Manage.ViewModels
{
    public class ModelViewModel
    {
        public List<Model> Models { get; set; }
        public List<Brand> Brands { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
    }

}
