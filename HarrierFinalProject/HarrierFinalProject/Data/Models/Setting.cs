using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HarrierFinalProject.Data.Models
{
    public class Setting
    {
        public int Id { get; set; }
        public string HeaderLogo { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        [NotMapped]
        public IFormFile HeaderImg { get; set; }

    }
}
