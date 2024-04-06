using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebProject.ModelAccessLayer.Model
{
    public class RegistrationData
    {
        [Required(ErrorMessage = "Enter a username")]
        [Display(Name = "User Name")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Login must be at least 4 characters long")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter an email")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter a phone number")]
        [Display(Name = "Phone Number")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Enter a password")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long")]
        public string Password { get; set; }

        public RegistrationData() { }
    }
}
