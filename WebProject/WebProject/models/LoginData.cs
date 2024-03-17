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
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter Password")]
        public string Password { get; set; }

        public LoginData() { }

        public LoginData(string email, string password)
        {
            this.Email = email;    
            this.Password = password;
        }

        /**************************************************Модели не принимают эту информацию**********************************************/
        //[Display(Name = "Remember Me")]
        //public bool RememberMe { get; set; } нет такого функционала
        //public string ForgotPasswordUrl { get; set; } - этот функционал мы не реализуем
        //public string RegisterUrl { get; set; }  - не понял для чеего ????
        //public int PasswordExpirationDays { get; set; } ??? тоже ссамое не понял
        //public int MaxLoginAttempts { get; set; } ??? тоже самое не понял
    }
}