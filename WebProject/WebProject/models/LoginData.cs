using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebProject.Models
{
    public class LoginData
    {
        [Required(ErrorMessage = "Enter Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }

        public string ForgotPasswordUrl { get; set; }

        public string RegisterUrl { get; set; }

        //public int PasswordExpirationDays { get; set; } ???
        //public int MaxLoginAttempts { get; set; } ???

        public string ErrorMessage { get; set; }
       /*-----TRANSPORT THAT TO CONTROLLERS
        public bool IsValidUser()
        {
            if (string.IsNullOrEmpty(Username)) return false;
            //Probably here will be all verifying stuff with database
            return true;
        }
        public bool IsValidPassword()
        {
            if (Password == null) return false;
            //Probably here will be all verifying stuff with database
            return true;
        }*/ 
    }
}