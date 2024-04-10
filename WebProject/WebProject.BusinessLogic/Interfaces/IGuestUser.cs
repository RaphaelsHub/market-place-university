using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.ModelAccessLayer.Model;
using WebProject.Domain.Enum;

namespace WebProject.BusinessLogic.Interfaces
{
    internal interface IGuestUser
    {
        UserData Register(RegistrationData registrationData);
        UserData Login(LoginData loginData);
    }
}
