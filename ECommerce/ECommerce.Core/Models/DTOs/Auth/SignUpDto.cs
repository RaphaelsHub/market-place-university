using System.ComponentModel.DataAnnotations;

namespace ECommerce.Core.Models.DTOs.Auth
{
    public class SignUpDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(32, MinimumLength = 1, ErrorMessage = "Name must be between 1 and 32 characters")]
        [RegularExpression(@"^[a-zA-Z\s'-]+$", ErrorMessage = "Name must contain only letters, spaces, apostrophes, or hyphens")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "Email must be less than 320 characters")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Password is required")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 50 characters")]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{8,}$", ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one number, and be at least 8 characters long")]
        [DataType(DataType.Password, ErrorMessage = "Invalid Password")]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "Confirm Password is required")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match")]
        public string ConfirmPassword { get; set; }

        public bool SignUpForNewsletter { get; set; }
    }
}