using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.Core.DataTransferObjects.AuthDto;
using ECommerce.Core.DataTransferObjects.FeedBack.Standard;

namespace ECommerce.App.Interfaces
{
    //Not really sure about the methods, but I think they will need to be improved and added more methods after architecture review
    public interface IAuthService
    {
        Task<ResponseType1<bool>> Register(SignUpDto registrationDto);
        Task<ResponseType1<bool>> SendEmailConfirmation(string email);
        Task<ResponseType1<string>> RefreshToken(string refreshToken);
        Task<ResponseType1<bool>> ConfirmEmail(string email, string token);

        Task<ResponseType1<bool>> Login(SignInDto loginDto);
        Task<ResponseType1<bool>> Logout();

        //Reset Password
        Task<ResponseType1<bool>> ForgotPassword(string email);
        Task<ResponseType1<bool>> ChangePassword(string changePasswordDto);
        Task<ResponseType1<bool>> VerifySentCode(string email, string code);
        
        //2FA
        Task<ResponseType1<bool>> EnableTwoFactorAuthentication();
        Task<ResponseType1<bool>> DisableTwoFactorAuthentication();
        
        //Account Status
        Task<ResponseType1<bool>> EnableAccount();
        Task<ResponseType1<bool>> DisableAccount();
        Task<ResponseType1<bool>> BlockAccount();
        Task<ResponseType1<bool>> UnblockAccount();
        
        //Account Verification Status
        Task<ResponseType1<bool>> SetVerificationStatus(string userId, bool status);
        
        //Account Role
        Task<ResponseType1<bool>> SetRole(string userId, string role);
        Task<IEnumerable<string>> GetRoles();
        
        //User Status
        Task<ResponseType1<bool>> SetUserStatus(string userId, string status); //Online, Offline
        
        //TO DO: Add more methods
    }
}