using System.Collections.Generic;
using System.Threading.Tasks;
using WebProject.Core.DTO;
using WebProject.Core.DTO.ResponcesDto;

namespace WebProject.App.Interfaces
{
    //Not really sure about the methods, but I think they will need to be improved and added more methods after architecture review
    public interface IAuthService
    {
        Task<Response<bool>> Register(RegisterDto registrationDto);
        Task<Response<bool>> SendEmailConfirmation(string email);
        Task<Response<string>> RefreshToken(string refreshToken);
        Task<Response<bool>> ConfirmEmail(string email, string token);

        Task<Response<bool>> Login(LoginDto loginDto);
        Task<Response<bool>> Logout();

        //Reset Password
        Task<Response<bool>> ForgotPassword(string email);
        Task<Response<bool>> ChangePassword(string changePasswordDto);
        Task<Response<bool>> VerifySentCode(string email, string code);
        
        //2FA
        Task<Response<bool>> EnableTwoFactorAuthentication();
        Task<Response<bool>> DisableTwoFactorAuthentication();
        
        //Account Status
        Task<Response<bool>> EnableAccount();
        Task<Response<bool>> DisableAccount();
        Task<Response<bool>> BlockAccount();
        Task<Response<bool>> UnblockAccount();
        
        //Account Verification Status
        Task<Response<bool>> SetVerificationStatus(string userId, bool status);
        
        //Account Role
        Task<Response<bool>> SetRole(string userId, string role);
        Task<IEnumerable<string>> GetRoles();
        
        //User Status
        Task<Response<bool>> SetUserStatus(string userId, string status); //Online, Offline
        
        //TO DO: Add more methods
    }
}