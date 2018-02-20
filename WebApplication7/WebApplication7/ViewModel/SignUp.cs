using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication7.ViewModel
{
    public class SignUp
    {
        [RegularExpression("([A-Za-z ]+)", ErrorMessage = "Invalid Name")]
        public string Name { get; set; }
        [RegularExpression("([A-Za-z0-9._%+-]+@tkxel.com)", ErrorMessage = "Invalid Email")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        [Compare("Password")]
        [Required]
        [Display(Name="Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

    }
}
