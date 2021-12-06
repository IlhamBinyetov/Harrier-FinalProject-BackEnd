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
    }
}
