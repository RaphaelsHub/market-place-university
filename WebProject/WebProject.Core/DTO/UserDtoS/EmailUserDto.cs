using System.ComponentModel.DataAnnotations;

namespace WebProject.Core.DTO.UserDtoS
{
    public class EmailUserDto
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(320, MinimumLength = 1, ErrorMessage = "Email must be less than 320 characters")]
        public string Email { get; set; }
    }
}