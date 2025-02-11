using System;
using System.Threading.Tasks;
using ECommerce.App.Interfaces.Auth;
using ECommerce.Core.DataTransferObjects.FeedBack.Standard;
using ECommerce.Core.Enums.User;

namespace ECommerce.App.Services.Auth
{
    public class AccountManagementService : IAccountManagementService
    {
        public Task<ResponseType1<bool>> ChangePassword(string changePasswordDto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseType1<bool>> SetAccountStatus(int userId, UserStatus status)
        {
            throw new NotImplementedException();
        }
    }
}


