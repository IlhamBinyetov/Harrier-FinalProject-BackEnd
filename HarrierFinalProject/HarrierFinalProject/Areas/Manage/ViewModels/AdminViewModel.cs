using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HarrierFinalProject.Areas.Manage.ViewModels
{
    public class AdminViewModel
    {
        public string Id { get; set; }

        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 6, ErrorMessage = "min 6, max 50 ola biler")]
        public string UserName { get; set; }



        [Required]
        [StringLength(maximumLength: 30, MinimumLength = 6, ErrorMessage = "min 6, max 30 ola biler")]
        [DataType(DataType.Password)]
        public string Password { get; set; }



        [Required]
        [StringLength(maximumLength: 25, MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }



        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 6)]
        public string FullName { get; set; }



        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 6)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
