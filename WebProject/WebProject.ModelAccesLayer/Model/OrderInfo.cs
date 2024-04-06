using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebProject.ModelAccessLayer.Model
{
    public class OrderInfo
    {
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please enter your email")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        [Display(Name = "Phone")]
        [Required(ErrorMessage = "Please enter your phone number")]
        [Phone(ErrorMessage = "Please enter a valid phone number")]
        public string Phone { get; set; }

        [Display(Name = "Country")]
        [Required(ErrorMessage = "Please enter your country")]
        public string Country { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "Please enter your city")]
        public string City { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Please enter your address")]
        public string Address { get; set; }

        [Display(Name = "Comment(Optional)")]
        public string Comment { get; set; }

        public OrderInfo() { }

        public OrderInfo(string name, string email, string phone, string country, string city, string address, string comment)
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
