using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrierFinalProject.Data.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public DateTime PostDate { get; set; }
        public string Email { get; set; }

        public int? CarId { get; set; }
        public Car Car { get; set; }
        public int? BlogId { get; set; }
        public Blog Blog { get; set; }


    }
}
