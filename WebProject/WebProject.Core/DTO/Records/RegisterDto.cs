using System.ComponentModel.DataAnnotations;

namespace WebProject.Core.DTO.Records
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Please enter your first name")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "Please enter your email address")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Please enter your password")]
        [StringLength(63, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "Please confirm your password")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}