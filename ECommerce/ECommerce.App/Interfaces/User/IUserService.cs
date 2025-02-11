using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.Core.DataTransferObjects.FeedBack.ErrorSuccess;
using ECommerce.Core.DataTransferObjects.FeedBack.Standard;
using ECommerce.Core.DataTransferObjects.User;

namespace ECommerce.App.Interfaces.User
{
    /// <summary>
    ///  User service, which allows to create, read, update, delete user, find user by email, find user by username
    /// </summary>
    public interface IUserService
    {
        Task<bool> CreateUserAsync(UserDto user);
        Task<ResponseType1<UserDto>> GetUserAsync(int id);
        Task<ResponseType1<UserDto>> FindUserByEmailAsync(string email);
        Task<ResponseType1<UserDto>> FindUserByUserNameAsync(string userName, int currentPage = 1, int amountOfUsers = 16);
        Task<ResponseType1<IEnumerable<UserDto>>> GetUsersAsync(int currentPage = 1, int amountOfUsers = 16);
        Task<bool> UpdateUserAsync(UserDto user);
        Task<bool> DeleteUserAsync(int id);
    }
}