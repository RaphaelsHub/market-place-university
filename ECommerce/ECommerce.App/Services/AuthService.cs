using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.App.Interfaces;
using ECommerce.Core.DataTransferObjects.AuthDto;
using ECommerce.Core.DataTransferObjects.FeedBack.Standard;
using ECommerce.Core.Entities.User;
using ECommerce.Core.Interfaces.User;

namespace ECommerce.App.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUsersRepository<UserEf> _usersRepository;
        
        public AuthService (IUsersRepository<UserEf> usersRepository)
        {
            _usersRepository = usersRepository;
        }
        
        public Task<ResponseType1<bool>> Register(SignUpDto registrationDto)
        {
            return Task.FromResult(new ResponseType1<bool>());
        }

        public Task<ResponseType1<bool>> SendEmailConfirmation(string email)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseType1<string>> RefreshToken(string refreshToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseType1<bool>> ConfirmEmail(string email, string token)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseType1<bool>> Login(SignInDto loginDto)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseType1<bool>> Logout()
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseType1<bool>> ForgotPassword(string email)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseType1<bool>> ChangePassword(string changePasswordDto)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseType1<bool>> VerifySentCode(string email, string code)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseType1<bool>> EnableTwoFactorAuthentication()
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseType1<bool>> DisableTwoFactorAuthentication()
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseType1<bool>> EnableAccount()
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseType1<bool>> DisableAccount()
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseType1<bool>> BlockAccount()
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseType1<bool>> UnblockAccount()
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseType1<bool>> SetVerificationStatus(string userId, bool status)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseType1<bool>> SetRole(string userId, string role)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<string>> GetRoles()
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseType1<bool>> SetUserStatus(string userId, string status)
        {
            throw new System.NotImplementedException();
        }
    }
}


