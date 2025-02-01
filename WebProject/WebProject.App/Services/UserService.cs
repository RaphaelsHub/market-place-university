using System.Collections.Generic;
using System.Threading.Tasks;
using WebProject.App.Interfaces;
using WebProject.Core.DTO;
using WebProject.Core.DTO.FeedBack.Standard;

namespace WebProject.App.Services
{
    public class UserService : IUserService
    {
        public Task<Response<UserDto>> GetUserById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<UserDto>> GetUserByEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<UserDto>> GetUserByUserName(string userName)
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<IEnumerable<UserDto>>> GetUsers()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> AddUser(UserDto user)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateUser(UserDto user)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteUser(UserDto user)
        {
            throw new System.NotImplementedException();
        }
    }
}

