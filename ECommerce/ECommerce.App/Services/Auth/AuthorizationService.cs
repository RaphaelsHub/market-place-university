using System.Threading.Tasks;
using ECommerce.App.Interfaces.Auth;
using ECommerce.Core.Enums.User;
using ECommerce.Core.Models.ViewModels;

namespace ECommerce.App.Services.Auth
{
    public class AuthorizationService : IAuthorizationService
    {
        public Task<ResponseViewModel<bool>> SetRole(int userId, UserType role)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseViewModel<bool>> CheckRole(int userId, UserType role)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseViewModel<UserType>> GetUserRole(int userId)
        {
            throw new System.NotImplementedException();
        }
    }
}