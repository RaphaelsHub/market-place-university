using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.Core.DataTransferObjects.FeedBack.Standard;
using ECommerce.Core.DataTransferObjects.User;

namespace ECommerce.App.Interfaces
{
    public interface IUserService
    {
        Task<ResponseType1<UserDto>> GetUserById(int id);
        Task<ResponseType1<UserDto>> GetUserByEmail(string email);
        Task<ResponseType1<UserDto>> GetUserByUserName(string userName);
        Task<ResponseType1<IEnumerable<UserDto>>> GetUsers();
        Task<bool> AddUser(UserDto user);
        Task<bool> UpdateUser(UserDto user);
        Task<bool> DeleteUser(UserDto user);
        
    }
}