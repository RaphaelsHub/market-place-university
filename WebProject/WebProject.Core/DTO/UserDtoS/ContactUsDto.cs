using System.ComponentModel.DataAnnotations;

namespace WebProject.Core.DTO.UserDtoS
{
    public class ContactUsDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters")]
        [RegularExpression(@"^[a-zA-Z\s'-]+$", ErrorMessage = "Name must contain only letters, spaces, apostrophes, or hyphens")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(320, MinimumLength = 1, ErrorMessage = "Email must be less than 320 characters")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Phone Number is required")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Invalid Phone Number")]
        [RegularExpression(@"^\+?[0-9]+$", ErrorMessage = "Phone Number must contain only numbers and an optional plus sign")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Phone Number must be between 10 and 20 characters")]
        public string PhoneNumber { get; set; }
        
        [Required(ErrorMessage = "Subject is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Subject must be between 3 and 50 characters")]
        [RegularExpression(@"^[a-zA-Z0-9\s!?.,'-]+$", ErrorMessage = "Subject must contain only letters, numbers, and basic punctuation")]
        public string Subject { get; set; }
        
        [Required(ErrorMessage = "Message is required")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Message must be between 10 and 500 characters")]
        public string Message { get; set; }
    }
}