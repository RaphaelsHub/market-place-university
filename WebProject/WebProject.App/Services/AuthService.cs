using System.Collections.Generic;
using System.Threading.Tasks;
using WebProject.App.Interfaces;
using WebProject.Core.DTO;
using WebProject.Core.DTO.FeedBack.Standard;
using WebProject.Core.DTO.User;

namespace WebProject.App.Services
{
    public class AuthService : IAuthService
    {
        public Task<ResponseType1<bool>> Register(SignUpDto registrationDto)
        {
            throw new System.NotImplementedException();
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


