using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.ModelAccessLayer.Model;
using WebProject.Domain.Enum;

namespace WebProject.BusinessLogic.Interfaces
{
    public interface IGuest
    {
        UserData Register(RegistrationData registrationData);
        UserData Login(LoginData loginData);
    }
}
