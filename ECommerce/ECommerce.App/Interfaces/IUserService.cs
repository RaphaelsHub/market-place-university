using System.Collections.Generic;
using System.Threading.Tasks;
using WebProject.Core.DTO;
using WebProject.Core.DTO.FeedBack.Standard;
using WebProject.Core.DTO.User;

namespace WebProject.App.Interfaces
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