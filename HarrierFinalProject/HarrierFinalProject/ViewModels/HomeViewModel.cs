using HarrierFinalProject.Data.Models;
using HarrierFinalProject.Models;
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
    }
}
