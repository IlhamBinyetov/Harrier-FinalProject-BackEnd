using HarrierFinalProject.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrierFinalProject.Areas.Manage.ViewModels
{
    public class DashViewModel
    {
        public List<Car> Cars { get; set; }
        public Car Car { get; set; }
        public  List<Order> Orders { get; set; }
        public List<Order> PendingOrders { get; set; }
    }
}
