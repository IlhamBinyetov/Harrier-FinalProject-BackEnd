using HarrierFinalProject.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HarrierFinalProject.Data.Models
{
    public class Order
    {
        public int Id { get; set; }

        [StringLength(maximumLength: 250)]
        public string Address { get; set; }
         

        [StringLength(maximumLength: 25)]
        public string Phone { get; set; }

        public DateTime CreatedAt { get; set; }
        public OrderStatus Status { get; set; } 
        public Car Car { get; set; }
        public int CarId { get; set; }

        public AppUser AppUser { get; set; }
        public string AppUserId { get; set; } 

        public City City { get; set; }
        public int CityId { get; set; }
    }
}
