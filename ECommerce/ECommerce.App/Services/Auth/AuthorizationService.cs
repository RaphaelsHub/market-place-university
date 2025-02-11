using System.Threading.Tasks;
using ECommerce.App.Interfaces.Auth;
using ECommerce.Core.DataTransferObjects.FeedBack.Standard;
using ECommerce.Core.Enums.User;

namespace ECommerce.App.Services.Auth
{
    public class AuthorizationService : IAuthorizationService
    {
        public Task<ResponseType1<bool>> SetRole(int userId, UserType role)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseType1<bool>> CheckRole(int userId, UserType role)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseType1<UserType>> GetUserRole(int userId)
        {
            throw new System.NotImplementedException();
        }
    }
}