using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrierFinalProject.Data.Models
{
    public class CarImage
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public bool IsPoster { get; set; }



        public int CarId { get; set; }
        public Car Car { get; set; }
        
    }
}
