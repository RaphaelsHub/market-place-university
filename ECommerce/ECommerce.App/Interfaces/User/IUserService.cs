using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.Core.Models.DTOs.User;
using ECommerce.Core.Models.ViewModels;

namespace ECommerce.App.Interfaces.User
{
    /// <summary>
    ///  User service, which allows to create, read, update, delete user, find user by email, find user by username
    /// </summary>
    public interface IUserService
    {
        Task<bool> CreateUserAsync(UserDto user);
        Task<ResponseViewModel<UserDto>> GetUserAsync(int id);
        Task<ResponseViewModel<UserDto>> FindUserByEmailAsync(string email);
        Task<ResponseViewModel<UserDto>> FindUserByUserNameAsync(string userName, int currentPage = 1, int amountOfUsers = 16);
        Task<ResponseViewModel<IEnumerable<UserDto>>> GetUsersAsync(int currentPage = 1, int amountOfUsers = 16);
        Task<bool> UpdateUserAsync(UserDto user);
        Task<bool> DeleteUserAsync(int id);
    }
}