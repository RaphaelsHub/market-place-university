using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProject.Models
{
    public class RegistrationData
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }

        // Конструктор без параметров
        public RegistrationData(){}

        // Конструктор с параметрами
        public RegistrationData(string name, string email, string phone, string password)
        {
            Name = name;
            Email = email;
            Phone = phone;
            Password = password;
        }
    }

}