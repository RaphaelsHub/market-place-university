using System.ComponentModel.DataAnnotations;

namespace WebProject.Core.DTO.AuthDto
{
    public class SignUpDto : SignInDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(32, MinimumLength = 1, ErrorMessage = "Name must be between 1 and 32 characters")]
        [RegularExpression(@"^[a-zA-Z\s'-]+$", ErrorMessage = "Name must contain only letters, spaces, apostrophes, or hyphens")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Confirm Password is required")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match")]
        public string ConfirmPassword { get; set; }

        public bool SignUpForNewsletter { get; set; }
    }
}