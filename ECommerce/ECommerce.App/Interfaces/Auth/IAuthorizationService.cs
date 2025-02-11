using System.Threading.Tasks;
using ECommerce.Core.DataTransferObjects.FeedBack.Standard;
using ECommerce.Core.Enums.User;

namespace ECommerce.App.Interfaces.Auth
{
    /// <summary>
    /// Authorization service, which allows to set role and check role
    /// </summary>
    public interface IAuthorizationService
    {
        Task<ResponseType1<bool>> SetRole(int userId, UserType role);
        Task<ResponseType1<bool>> CheckRole(int userId, UserType role);
        Task<ResponseType1<UserType>> GetUserRole(int userId);
    }
}