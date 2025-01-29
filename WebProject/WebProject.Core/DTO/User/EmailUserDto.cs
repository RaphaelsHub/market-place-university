using System.ComponentModel.DataAnnotations;

namespace WebProject.Core.DTO.User
{
    public class EmailUserDto
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "Email must be less than 255 characters")]
        public string Email { get; set; }
    }
}