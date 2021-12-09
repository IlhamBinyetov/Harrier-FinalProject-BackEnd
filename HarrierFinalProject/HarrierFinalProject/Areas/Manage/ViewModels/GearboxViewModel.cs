using HarrierFinalProject.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrierFinalProject.Areas.Manage.ViewModels
{
    public class GearboxViewModel
    {
        public string Name { get; set; }
        public List<Gearbox> Gearboxes { get; set; }
        public Gearbox Gearbox { get; set; }
     }
}
