using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using WebProject.Core.Enums;

namespace WebProject.Core.Entities
{
    [Table("Users")]
    public class UserEf
    {
        /// <summary>
        /// Gets or sets the unique identifier for the user.
        /// </summary>
        [Key]
        public uint UserId { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        [Required]
        [StringLength(31, MinimumLength = 4)]
        public string Name { get; set; } = "";

        /// <summary>
        /// Gets or sets the email of the user.
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";

        /// <summary>
        /// Gets or sets the password hash for the user.
        /// </summary>
        [Required]
        [StringLength(255)]
        public string PasswordHash { get; set; } = "";

        /// <summary>
        /// Gets or sets the date when the user registered.
        /// </summary>
        public DateTime DateRegistered { get; set; } = DateTime.Now;

        /// <summary>
        /// Gets or sets the user type.
        /// </summary>
        public UserType UserType { get; set; } = UserType.User;

        /// <summary>
        /// Gets or sets the user status.
        /// </summary>
        public UserStatus UserStatus { get; set; } = UserStatus.Inactive;

        /// <summary>
        /// Gets or sets the account verification status.
        /// </summary>
        public AccountVerificationStatus IsVerified { get; set; } = AccountVerificationStatus.NotVerified;

        /// <summary>
        /// Gets or sets a value indicating whether the user wants to be remembered.
        /// </summary>
        public bool RememberMe { get; set; } = false;

        /// <summary>
        /// Gets or sets a value indicating whether the user has signed up for the newsletter.
        /// </summary>
        public bool IsSignUpForNewsletter { get; set; } = false;

        /// <summary>
        /// Gets or sets the IP address of the user.
        /// </summary>
        [Required]
        public IPAddress IpAddress { get; set; }

        /// <summary>
        /// Gets or sets the list of addresses associated with the user.
        /// </summary>
        public List<AddressEf> Addresses { get; set; } = new List<AddressEf>();
        
        public List<ProductEf> Cart { get; set; } = new List<ProductEf>();
    }
}
