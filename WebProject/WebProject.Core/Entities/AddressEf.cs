using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProject.Core.Entities
{
    public class AddressEf
    {
        [Key]
        public uint AddressId { get; set; }
        
        [Required]
        [MaxLength(127)]
        public string FirstName { get; set; } = ""; 
        
        [Required]
        [MaxLength(127)]
        public string LastName { get; set; } = "";
        
        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";
        
        [Required]
        [Phone]
        public string Phone { get; set; } = "";
        
        [Required]
        public string Country { get; set; } = "";
        
        [Required]
        public string City { get; set; } = "";
        
        [Required]
        public string Address1 { get; set; } = "";
        
        [Required]
        public string Address2 { get; set; } = "";
        
        [Required]
        public string PostalCode { get; set; } = "";
        
        [ForeignKey("User")]
        public uint UserId { get; set; }
        
        public UserEf User { get; set; }
    }
}