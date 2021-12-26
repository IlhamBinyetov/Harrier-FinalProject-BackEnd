using HarrierFinalProject.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrierFinalProject.ViewModels
{
    public class ContactViewModel
    {
        public Contact Contact { get; set; }
        public List<Advertising> Advertisings { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string Messsage { get; set; }
        public string Email { get; set; }
        public AppUser AppUser { get; set; }
    }
}
