using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using WebProject.Core.Enums;
using WebProject.Core.Enums.Account;
using WebProject.Core.Enums.User;

namespace WebProject.Core.Entities
{
    [Table("Users")]
    public class UserEf
    {
        /// <summary>
        /// Gets or sets the unique identifier for the user.
        /// </summary>
        [Key]
        [Column("UserId")]
        public uint UserId { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        [Required]
        [MaxLength(32)]
        [Column("Name")]
        public string Name { get; set; } = "";

        /// <summary>
        /// Gets or sets the email of the user.
        /// </summary>
        [Required]
        [EmailAddress]
        [MaxLength(255)]
        [Column("Email")]
        public string Email { get; set; } = "";

        /// <summary>
        /// Gets or sets the password hash for the user.
        /// </summary>
        [Required]
        [StringLength(255)]
        [Column("PasswordHash")]
        public string PasswordHash { get; set; } = "";

        /// <summary>
        /// Gets or sets the date when the user registered.
        /// </summary>
        [Required]
        [Column("DateRegistered")]
        public DateTime DateRegistered { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Gets or sets the user type.
        /// </summary>
        [Required]
        [Column("UserType")]
        public UserType UserType { get; set; } = UserType.User;

        /// <summary>
        /// Gets or sets the user status.
        /// </summary>
        [Required]
        [Column("UserStatus")]
        public UserStatus UserStatus { get; set; } = UserStatus.Online;
        
        /// <summary>
        /// Gets or sets the account verification status.
        /// </summary>
        [Required]
        [Column("IsVerified")]
        public AccountVerificationStatus IsVerified { get; set; } = AccountVerificationStatus.NotVerified;

        /// <summary>
        /// Gets or sets a value indicating whether the user wants to be remembered.
        /// </summary>
        [Column("RememberMe")]
        public bool RememberMe { get; set; } = false;

        /// <summary>
        /// Gets or sets a value indicating whether the user has signed up for the newsletter.
        /// </summary>
        [Column("IsSignUpForNewsletter")]
        public bool IsSignUpForNewsletter { get; set; } = false;

        /// <summary>
        /// Gets or sets the IP address of the user.
        /// Stored as string in the database but represented as IPAddress in the application.
        /// </summary>
        [Required]
        [Column("IpAddress")]
        public string IpAddress
        {
            get => _ipAddress.ToString();
            set => _ipAddress = IPAddress.Parse(value);
        }

        [NotMapped]
        private IPAddress _ipAddress;

        /// <summary>
        /// Gets or sets the list of addresses associated with the user.
        /// </summary>
        [InverseProperty("User")]
        public List<AddressEf> Addresses { get; set; } = new List<AddressEf>();

        /// <summary>
        /// Gets or sets the list of orders associated with the user.
        /// </summary>
        [InverseProperty("User")]
        public List<OrderEf> Orders { get; set; } = new List<OrderEf>();

        /// <summary>
        /// Gets or sets the list of products in the cart associated with the user.
        /// </summary>
        [InverseProperty("User")]
        public List<CartEf> Cart { get; set; } = new List<CartEf>();
    }
}
