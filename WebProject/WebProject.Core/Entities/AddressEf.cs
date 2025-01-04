using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProject.Core.Entities
{
    public class AddressEf
    {
        /// <summary>
        ///  The unique identifier for the address.
        /// </summary>
        [Key]
        public uint AddressId { get; set; }
        
        /// <summary>
        /// The first name of the user.
        /// </summary>
        [Required]
        [MaxLength(127)]
        public string FirstName { get; set; } = ""; 
        
        /// <summary>
        /// The last name of the user.
        /// </summary>
        [Required]
        [MaxLength(127)]
        public string LastName { get; set; } = "";
        
        /// <summary>
        /// The email of the user.
        /// </summary>
        [Required]
        [EmailAddress]
        [MaxLength(255)]
        public string Email { get; set; } = "";
        
        /// <summary>
        /// The phone number of the user.
        /// </summary>
        [Required]
        [Phone]
        public string Phone { get; set; } = "";
        
        /// <summary>
        /// The country of the user.
        /// </summary>
        [Required]
        public string Country { get; set; } = "";
        
        /// <summary>
        /// The city of the user.
        /// </summary>
        [Required]
        public string City { get; set; } = "";
        
        /// <summary>
        /// The first address line of the user.
        /// </summary>
        [Required]
        public string Address1 { get; set; } = "";
        
        /// <summary>
        /// The second address line of the user.
        /// </summary>
        [Required]
        public string Address2 { get; set; } = "";
        
        /// <summary>
        /// The postal code of the user.
        /// </summary>
        [Required]
        public string PostalCode { get; set; } = "";
        
        /// <summary>
        /// The user identifier.
        /// </summary>
        [Required]
        [Range(0, uint.MaxValue)]
        public uint UserId { get; set; }
        [ForeignKey("UserId")]
        public UserEf User { get; set; }
    }
}