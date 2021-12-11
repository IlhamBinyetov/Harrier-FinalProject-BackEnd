using HarrierFinalProject.Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrierFinalProject.Areas.Manage.ViewModels
{
    public class BlogViewModel
    {
        public List<Blog> Blogs { get; set; } 
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile ImageFile { get; set; }
        public string PostedBy { get; set; }
        public DateTime PostDate { get; set; }

    }
}
