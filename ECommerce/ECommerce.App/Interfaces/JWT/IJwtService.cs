using System;
using System.Threading.Tasks;
using ECommerce.Core.Entities.User;

namespace ECommerce.App.Interfaces.JWT
{
    public interface IJwtService
    {
        string GenerateToken(UserEf user);
        int GetUserIdFromToken(string token);
        int GetUserRoleIdFromToken(string token);
        string GetUserEmailFromToken(string token);
        Task<bool> IsTokenValid(string token);
        Task<bool> IsTokenValid();
    }
}