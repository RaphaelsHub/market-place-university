using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using WebProject.Core.Enums.Account;
using WebProject.Core.Enums.User;

namespace WebProject.Core.Entities.User
{
    public class UserEf
    {
        public int UserId { get; set; } 
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string PasswordHash { get; set; } = "";
        public DateTime DateRegistered { get; set; } = DateTime.UtcNow;
        public UserType UserType { get; set; } = UserType.User;
        public UserStatus UserStatus { get; set; } = UserStatus.Offline;
        public AccountVerificationStatus IsVerified { get; set; } = AccountVerificationStatus.NotVerified;
        public bool RememberMe { get; set; } = false;
        public bool IsSignUpForNewsletter { get; set; } = false;
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
