using System.ComponentModel.DataAnnotations;
using ECommerce.Core.Enums.Order;

namespace ECommerce.Core.Models.DTOs.Order
{
    public class OrderDataDto
    {
        [Required(ErrorMessage = "FirstName is required")]
        [StringLength(32, MinimumLength = 2, ErrorMessage = "FirstName must be between 2 and 32 characters")]
        [RegularExpression(@"^[a-zA-Z\s'-]+$", ErrorMessage = "FirstName must contain only letters, spaces, apostrophes, or hyphens")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "LastName is required")]
        [StringLength(32, MinimumLength = 2, ErrorMessage = "LastName must be between 2 and 32 characters")]
        [RegularExpression(@"^[a-zA-Z\s'-]+$", ErrorMessage = "LastName must contain only letters, spaces, apostrophes, or hyphens")]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "Email must be less than 255 characters")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "PhoneNumber is required")]
        [RegularExpression(@"^(\+)?[0-9\s-]{9,}$", ErrorMessage = "Invalid Phone Number")]
        public string PhoneNumber { get; set; }
        
        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; }
        
        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }
        
        [Required(ErrorMessage = "Address is required")]
        public string Address1 { get; set; }
        
        public string Address2 { get; set; }
        
        [Required(ErrorMessage = "PostalCode is required")]
        [RegularExpression(@"^[0-9]{2,}$", ErrorMessage = "Invalid Postal Code")]
        public string PostalCode { get; set; }
        
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Message must be between 10 and 100 characters")]
        public string OrderNote { get; set; }
        
    }
}