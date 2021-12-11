using HarrierFinalProject.Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrierFinalProject.Areas.Manage.ViewModels
{
    public class SettingViewModel
    {
        public List<Setting> Settings { get; set; }
        public Setting Setting { get; set; }
        public int SettingId { get; set; }
        public string Image { get; set; }

        public IFormFile ImageFile { get; set; }
    }
}
