using HarrierFinalProject.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrierFinalProject.Areas.Manage.ViewModels
{
    public class OrderViewModel
    {
        public List<Order> Orders { get; set; }
        public AppUser AppUser { get; set; }
        public Order Order { get; set; }
    }
}
