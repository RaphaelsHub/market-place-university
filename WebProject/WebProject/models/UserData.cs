using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebProject.Models
{
    public class UserData
    {
        [Required(ErrorMessage = "Enter Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        /*-----TRANSPORT THAT TO CONTROLLERS
         public bool isUserNameAlreadyUsed(string Username)
        {
            //Again veryfing it with database ig
            return true;
        }
        public bool IsValidUser()
        {
            if (string.IsNullOrEmpty(Username)) return false;
            //Veryfing if User hasn't typed some kind of stupid function for database
            return true;
        }*/
    }
}