using System.Threading.Tasks;
using ECommerce.Core.Enums.User;
using ECommerce.Core.Models.ViewModels;

namespace ECommerce.App.Interfaces.Auth
{
    /// <summary>
    /// Authorization service, which allows to set role and check role
    /// </summary>
    public interface IAuthorizationService
    {
        Task<ResponseViewModel<bool>> SetRole(int userId, UserType role);
        Task<ResponseViewModel<bool>> CheckRole(int userId, UserType role);
        Task<ResponseViewModel<UserType>> GetUserRole(int userId);
    }
}