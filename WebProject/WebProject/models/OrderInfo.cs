using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProject.Models
{
    public class OrderInfo
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone{ get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Comment { get; set; }
       public OrderInfo() { }
        public OrderInfo(string name,string email,string phone,string country,string city,string address,string comment) 
        {
            Name = name; 
            Email = email;
            Phone = phone;
            Country = country;
            City = city;
            Address = address;
            Comment = comment;
        }

    }
}