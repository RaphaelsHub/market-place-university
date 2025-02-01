using System.Collections.Generic;
using System.Threading.Tasks;
using WebProject.Core.DTO;
using WebProject.Core.DTO.FeedBack.Standard;

namespace WebProject.App.Interfaces
{
    public interface IUserService
    {
        Task<Response<UserDto>> GetUserById(int id);
        Task<Response<UserDto>> GetUserByEmail(string email);
        Task<Response<UserDto>> GetUserByUserName(string userName);
        Task<Response<IEnumerable<UserDto>>> GetUsers();
        Task<bool> AddUser(UserDto user);
        Task<bool> UpdateUser(UserDto user);
        Task<bool> DeleteUser(UserDto user);
        
    }
}