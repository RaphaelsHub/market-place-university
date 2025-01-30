using System.Collections.Generic;
using System.Threading.Tasks;
using WebProject.App.Interfaces;
using WebProject.Core.DTO;
using WebProject.Core.DTO.ResponcesDto;

namespace WebProject.App.Services
{
    public class AuthService : IAuthService
    {
        public Task<Response<bool>> Register(RegisterDto registrationDto)
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<bool>> SendEmailConfirmation(string email)
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<string>> RefreshToken(string refreshToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<bool>> ConfirmEmail(string email, string token)
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<bool>> Login(LoginDto loginDto)
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<bool>> Logout()
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<bool>> ForgotPassword(string email)
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<bool>> ChangePassword(string changePasswordDto)
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<bool>> VerifySentCode(string email, string code)
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<bool>> EnableTwoFactorAuthentication()
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<bool>> DisableTwoFactorAuthentication()
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<bool>> EnableAccount()
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<bool>> DisableAccount()
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<bool>> BlockAccount()
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<bool>> UnblockAccount()
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<bool>> SetVerificationStatus(string userId, bool status)
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<bool>> SetRole(string userId, string role)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<string>> GetRoles()
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<bool>> SetUserStatus(string userId, string status)
        {
            throw new System.NotImplementedException();
        }
    }
}


