using System.Threading.Tasks;
using ECommerce.Core.Enums.Entity;
using ECommerce.Core.Enums.User;
using ECommerce.Core.Models.ViewModels;

namespace ECommerce.App.Interfaces.Auth
{
    /// <summary>
    ///  Account management service, which allows to change password, enable account, block account, delete account
    /// </summary>
    public interface IAccountManagementService
    {
        Task<ResponseViewModel<bool>> ChangePassword(string changePasswordDto);
        Task<ResponseViewModel<bool>> SetAccountStatus(int userId, EntityStatus status);
    }
}