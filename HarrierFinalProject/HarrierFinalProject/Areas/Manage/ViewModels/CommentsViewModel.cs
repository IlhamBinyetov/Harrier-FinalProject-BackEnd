using HarrierFinalProject.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrierFinalProject.Areas.Manage.ViewModels
{
    public class CommentsViewModel
    {
        public Comment Comment { get; set; }
        public List<Comment> Comments { get; set; }
        public int CarId { get; set; }
        public string Description { get; set; }
    }
}
