using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HarrierFinalProject.Data.Models
{
    public class AppUser:IdentityUser
    {
        public string Fullname { get; set; }
        public bool IsAdmin { get; set; }
        public string ConnectionId { get; set; }
        public DateTime LastConnectedDate { get; set; }
        public string Image { get; set; }
        public List<Comment> Comments { get; set; }
        
        [NotMapped]
        public IFormFile ImageFile { get; set; }

    }
}
