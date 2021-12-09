using HarrierFinalProject.Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrierFinalProject.Areas.Manage.ViewModels
{
    public class SliderViewModel
    {
        public List<Slider> Sliders { get; set; }
        public Slider Slider { get; set; }
        public string Image { get; set; }

        public IFormFile ImageFile { get; set; }
    }
}
