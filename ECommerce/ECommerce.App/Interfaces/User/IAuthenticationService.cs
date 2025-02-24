using System.Threading.Tasks;
using ECommerce.Core.Models.DTOs.GenericResponses;
using ECommerce.Core.Models.DTOs.User;

namespace ECommerce.App.Interfaces.User
{
    public interface IAuthenticationService
    { 
        Task<BaseResponse<bool>> SignUp(SignUpDto registrationDto);
        Task<BaseResponse<bool>> SignIn(SignInDto loginDto);
        Task<BaseResponse<bool>> IsTokenValid();
        Task<BaseResponse<bool>> Logout();
        Task<BaseResponse<bool>> SendEmailConfirmation(string email);
    }
}