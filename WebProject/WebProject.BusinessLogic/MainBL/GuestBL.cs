using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.BusinessLogic.Interfaces;
using WebProject.Domain.Enum;
using WebProject.ModelAccessLayer.Model;

namespace WebProject.BusinessLogic.MainBL
{
    public class GuestBL : IGuestUser
    {
        public UserData Login(LoginData loginData)
        {
            UserData userData = new UserData();

            return userData;
        }

        public UserData Register(RegistrationData registrationData)
        {
            UserData userData = new UserData();

            return userData;
        }
    }
}
