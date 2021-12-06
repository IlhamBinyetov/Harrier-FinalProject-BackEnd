using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrierFinalProject.Data.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime PostDate { get; set; }
         public string PostedBy { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
