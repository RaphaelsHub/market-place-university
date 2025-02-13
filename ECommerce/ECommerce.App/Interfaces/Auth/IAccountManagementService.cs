using System.Threading.Tasks;
using ECommerce.Core.DataTransferObjects.Responses;
using ECommerce.Core.Enums.User;

namespace ECommerce.App.Interfaces.Auth
{
    /// <summary>
    ///  Account management service, which allows to change password, enable account, block account, delete account
    /// </summary>
    public interface IAccountManagementService
    {
        Task<ResponseType1<bool>> ChangePassword(string changePasswordDto);
        Task<ResponseType1<bool>> SetAccountStatus(int userId, UserStatus status);
    }
}