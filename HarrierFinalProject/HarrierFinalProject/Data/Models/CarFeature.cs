using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrierFinalProject.Data.Models
{
    public class CarFeature
    {
        public int Id { get; set; }

        public int CarId { get; set; }
        public Car  Car { get; set; }
        public int FeatureId { get; set; }
        public Feature Feature { get; set; }
    }
}
