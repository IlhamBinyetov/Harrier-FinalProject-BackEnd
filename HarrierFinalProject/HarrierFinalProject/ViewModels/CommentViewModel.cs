using HarrierFinalProject.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrierFinalProject.ViewModels
{
    public class CommentViewModel
    {
        public Comment Comment { get; set; }
        public List<Comment> Comments { get; set; }
        public int CarId { get; set; }
        public string Description { get; set; }
        public int BlogId { get; set; }

    }
}
