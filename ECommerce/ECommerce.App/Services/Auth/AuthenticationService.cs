using System;
using System.Threading.Tasks;
using ECommerce.App.Interfaces.Auth;
using ECommerce.Core.DataTransferObjects.AuthDto;
using ECommerce.Core.DataTransferObjects.Responses;
using ECommerce.Core.Entities.User;
using ECommerce.Core.Interfaces.User;
using ECommerce.Helper;

namespace ECommerce.App.Services.Auth
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UsersRepository _usersRepository;
        
        public AuthenticationService(UsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        
        public Task<ResponseType1<bool>> SignUp(SignUpDto registrationDto)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseType1<bool>> SignIn(SignInDto loginDto)
        {
            throw new Exception("Not implemented");
        }

        public Task<ResponseType1<bool>> Logout()
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseType1<bool>> SendEmailConfirmation(string email)
        {
            throw new System.NotImplementedException();
        }
    }
}