using HarrierFinalProject.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HarrierFinalProject.Areas.Manage.ViewModels
{
    public class ContactsViewModel
    {

        public Contact Contact { get; set; }
        public List<Advertising> Advertisings { get; set; }
        public List<Contact> Contacts { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string Messsage { get; set; }
        public string Email { get; set; }
        public AppUser AppUser { get; set; }
    }
}
