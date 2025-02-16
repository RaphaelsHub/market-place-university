using System.Threading.Tasks;
using ECommerce.Core.Models.DTOs.Auth;
using ECommerce.Core.Models.ViewModels;

namespace ECommerce.App.Interfaces.Auth
{
    /// <summary>
    ///  Authentication service, which allows to sign up, sign in, logout, send email confirmation
    /// </summary>
    public interface IAuthenticationService
    {
        Task<ResponseViewModel<bool>> SignUp(SignUpDto registrationDto);
        Task<ResponseViewModel<bool>> SignIn(SignInDto loginDto);
        Task<ResponseViewModel<bool>> Logout();
        Task<ResponseViewModel<bool>> SendEmailConfirmation(string email);
    }
}