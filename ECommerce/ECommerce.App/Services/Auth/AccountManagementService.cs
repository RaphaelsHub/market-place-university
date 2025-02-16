using System;
using System.Threading.Tasks;
using ECommerce.App.Interfaces.Auth;
using ECommerce.Core.Enums.Entity;
using ECommerce.Core.Enums.User;
using ECommerce.Core.Models.ViewModels;

namespace ECommerce.App.Services.Auth
{
    public class AccountManagementService : IAccountManagementService
    {
        public Task<ResponseViewModel<bool>> ChangePassword(string changePasswordDto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseViewModel<bool>> SetAccountStatus(int userId, EntityStatus status)
        {
            throw new NotImplementedException();
        }
    }
}


