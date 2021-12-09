using HarrierFinalProject.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrierFinalProject.Areas.Manage.ViewModels
{
    public class CarColorViewModel
    {
        public List<CarColor> CarColors { get; set; }
        public string Name { get; set; }
        public CarColor CarColor { get; set; }
    }
}
