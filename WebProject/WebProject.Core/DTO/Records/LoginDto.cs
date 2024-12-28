using System.ComponentModel.DataAnnotations;

namespace WebProject.Core.DTO.Records
{
    public class LoginDto
    {
        [Required (ErrorMessage = "Please enter your email address")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }
        
        [Required (ErrorMessage = "Please enter your password")]
        [StringLength(63, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}