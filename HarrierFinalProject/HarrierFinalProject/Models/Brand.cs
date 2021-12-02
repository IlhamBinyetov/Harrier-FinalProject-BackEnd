using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrierFinalProject.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Model> Models { get; set; }
    }
}
