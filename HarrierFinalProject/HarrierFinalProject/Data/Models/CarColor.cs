using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrierFinalProject.Data.Models
{
    public class CarColor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Car> Cars { get; set; }

    }
}
