using HarrierFinalProject.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrierFinalProject.Data
{
    public class Basket
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public Car Car { get; set; }
        public int CarId { get; set; }
    }
}
