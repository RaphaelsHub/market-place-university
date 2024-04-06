using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.BusinessLogic.Interfaces;
using WebProject.ModelAccessLayer.Model;

namespace WebProject.BusinessLogic.MainBL
{
    public class GuestBL : IGuestUser
    {
        public UserData Login(LoginData loginData)
        {
            UserData userData = null;

            return userData;
        }

        public UserData Register(RegistrationData registrationData)
        {
            UserData userData = null;

            return userData;
        }

        public AllProducts GetAllProducts()
        {
            AllProducts allProducts =null;

            return allProducts;
        }

        public Product GetProductById(int id)
        {
            //FIndProduct
            Product product = null;
            return product;
        }
    }
}
