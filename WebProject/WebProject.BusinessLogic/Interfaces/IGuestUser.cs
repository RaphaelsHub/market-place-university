using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.ModelAccessLayer.Model;


namespace WebProject.BusinessLogic.Interfaces
{
    public interface IGuestUser
    {
        UserData Register(RegistrationData registrationData);
        UserData Login(LoginData loginData);
        AllProducts GetAllProducts();
        Product GetProductById(int id);
    }
}
