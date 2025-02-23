using System.ComponentModel.DataAnnotations;

namespace ECommerce.Core.Models.DTOs.User
{
    public class SignInDto
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "Email must be less than 320 characters")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Password is required")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 50 characters")]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{8,}$", ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one number, and be at least 8 characters long")]
        [DataType(DataType.Password, ErrorMessage = "Invalid Password")]
        public string Password { get; set; }
        
        public bool RememberMe { get; set; }
    }
}