using System.Threading.Tasks;
using ECommerce.Core.Models.DTOs.User;

namespace ECommerce.App.Interfaces.JWT
{
    public interface IJwtService
    {
        Task<string> GenerateToken(UserDto user);
        Task<int> GetUserIdFromToken();
        Task<int> GetUserRoleIdFromToken();
        Task<string> GetUserEmailFromToken();
        Task<bool> IsTokenValid();
    }
}