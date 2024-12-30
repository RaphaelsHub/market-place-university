using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProject.Core.Entities
{
    public class AddressEf
    {
        [Key]
        [Column("AddressId")]
        public uint AddressId { get; set; }
        
        [Required(ErrorMessage = "Please enter your first name")]
        [StringLength(127, MinimumLength = 2, ErrorMessage = "First Name must be between 2 and 127 characters")]
        [Column("FirstName")]
        public string FirstName { get; set; } = ""; 
        
        [Required(ErrorMessage = "Please enter your last name")]
        [StringLength(127, MinimumLength = 2, ErrorMessage = "Last Name must be between 2 and 127 characters")]
        [Column("LastName")]
        public string LastName { get; set; } = "";
        
        [Required(ErrorMessage = "Please enter your email address")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; } = "";
        
        [Required(ErrorMessage = "Please enter your phone number")]
        [Phone(ErrorMessage = "Please enter a valid phone number")]
        public string Phone { get; set; } = "";
        
        [Required (ErrorMessage = "Please enter your country")]
        public string Country { get; set; } = "";
        
        [Required (ErrorMessage = "Please enter your city")]
        public string City { get; set; } = "";
        
        [Required (ErrorMessage = "Please enter your address")]
        public string Address1 { get; set; } = "";
        
        [Required (ErrorMessage = "Please enter your address")]
        public string Address2 { get; set; } = "";
        
        [Required (ErrorMessage = "Please enter your postal code")]
        public string PostalCode { get; set; } = "";
    }
}