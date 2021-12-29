using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HarrierFinalProject.ViewModels
{
    public class ResetPasswordViewModel
    {
        public string Email { get; set; }
        public string Token { get; set; }


        [Required]
        [StringLength(maximumLength: 25, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [StringLength(maximumLength: 25, MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
