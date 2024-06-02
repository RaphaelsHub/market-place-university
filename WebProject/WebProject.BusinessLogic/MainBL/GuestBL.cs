using System;
using System.Collections.Generic;
using WebProject.BusinessLogic.Core;
using WebProject.BusinessLogic.Core.Levels;
using WebProject.BusinessLogic.Interfaces;
using WebProject.Domain.DB;
using WebProject.ModelAccessLayer.Model;

namespace WebProject.BusinessLogic.MainBL
{
    public class GuestBL : UserBaseBL, IGuest
    {
        private readonly UserGuestAPI _guestAPI = new UserGuestAPI();

        public UserData Login(LoginData loginData)
        {
            var responseResult = _guestAPI.CheckLogin(loginData);

            return !responseResult.IsExist ? null : ModelGeneratingClass.GenerateUserData(responseResult.Data, GetProductById);
        }

        public UserData Register(RegistrationData registrationData)
        {
            var responseResult = _guestAPI.RegistrateUser(registrationData);

            return !responseResult.IsExist ? null : ModelGeneratingClass.GenerateUserData(responseResult.Data, GetProductById);
        }
    }
}
