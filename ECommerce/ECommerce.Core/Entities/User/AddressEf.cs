namespace ECommerce.Core.Entities.User
{
    public class AddressEf
    {
        public int AddressId { get; set; }
        public string FirstName { get; set; } = ""; 
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Country { get; set; } = "";
        public string City { get; set; } = "";
        public string Address1 { get; set; } = "";
        public string Address2 { get; set; } = "";
        public string PostalCode { get; set; } = "";
        public string OrderNote { get; set; } = "";


        public int UserId { get; set; }
        public UserEf User { get; set; }
    }
}