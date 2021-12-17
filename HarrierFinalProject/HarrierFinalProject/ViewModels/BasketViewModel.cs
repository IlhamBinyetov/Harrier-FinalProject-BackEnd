using HarrierFinalProject.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrierFinalProject.ViewModels
{
    public class BasketViewModel
    {
        public List<Car> Cars { get; set; }
        public Car Car { get; set; }
        public List<Advertising> Advertisings { get; set; }
        public  int CarId { get; set; }

        public string CarName { get; set; }
        public decimal CarPrice { get; set; }
        public string CarPosterImage { get; set; }
        public int Count { get; set; }

    }
}
