using System.Net;
using WebProject.Core.Enums.Account;
using WebProject.Core.Enums.User;

namespace WebProject.Core.DTO.User
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }        
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public IPAddress IpAddress { get; set; }
        public bool HasNewsletter { get; set; }
        public bool HadGotPromoCodeBySendingEmail { get; set; }
        public UserType UserType { get; set; }
        public UserStatus UserStatus { get; set; }
        public AccountVerificationStatus AccountVerificationStatus { get; set; }
    }
}