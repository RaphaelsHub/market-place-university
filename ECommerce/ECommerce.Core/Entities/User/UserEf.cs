using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using ECommerce.Core.Enums.Account;
using ECommerce.Core.Enums.Entity;
using ECommerce.Core.Enums.User;

namespace ECommerce.Core.Entities.User
{
    public class UserEf
    {
        public int UserId { get; set; } 
        public string FullName { get; set; } = "";
        public string Email { get; set; } = "";
        public string PasswordHash { get; set; } = "";
        public DateTime DateRegistered { get; set; } = DateTime.UtcNow;
        public UserType UserType { get; set; } = UserType.User;
        public EntityStatus UserStatus { get; set; } = EntityStatus.Active;
        public AccountVerificationStatus IsVerified { get; set; } = AccountVerificationStatus.NotVerified;
        public SignUpForLettersStatus IsSignUpForLetters { get; set; } = SignUpForLettersStatus.No;
        
        [NotMapped]
        private IPAddress _ipAddress;
        public string IpAddress
        {
            get => _ipAddress.ToString();
            set => _ipAddress = IPAddress.Parse(value);
        }
        
        public List<AddressEf> Addresses { get; set; } = new List<AddressEf>();
        public List<OrderEf> Orders { get; set; } = new List<OrderEf>();
        public List<CartItemEf> CartItems { get; set; } = new List<CartItemEf>();
    }
}
