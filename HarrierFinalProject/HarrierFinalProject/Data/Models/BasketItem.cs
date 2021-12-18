using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrierFinalProject.Data.Models
{
    public class BasketItem
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string AppUserId { get; set; }
        

        public Car Car { get; set; }
        public AppUser AppUser { get; set; }
        public int Count { get; set; }
        public List<City> Cities { get; set; }
    }
}
