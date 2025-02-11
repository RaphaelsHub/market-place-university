using System.Threading.Tasks;
using ECommerce.Core.DataTransferObjects.AuthDto;
using ECommerce.Core.DataTransferObjects.FeedBack.Standard;

namespace ECommerce.App.Interfaces.Auth
{
    /// <summary>
    ///  Authentication service, which allows to sign up, sign in, logout, send email confirmation
    /// </summary>
    public interface IAuthenticationService
    {
        Task<ResponseType1<bool>> SignUp(SignUpDto registrationDto);
        Task<ResponseType1<bool>> SignIn(SignInDto loginDto);
        Task<ResponseType1<bool>> Logout();
        Task<ResponseType1<bool>> SendEmailConfirmation(string email);
    }
}