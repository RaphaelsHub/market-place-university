using System.Collections.Generic;
using System.Threading.Tasks;
using WebProject.App.Interfaces;
using WebProject.Core.DTO;
using WebProject.Core.DTO.FeedBack.Standard;
using WebProject.Core.DTO.User;
using WebProject.Core.Entities.User;
using WebProject.Core.Interfaces.User;

namespace WebProject.App.Services
{
    public class UserService : IUserService
    {
        private readonly IUsersRepository<UserEf> _usersRepository;
        
        public UserService(IUsersRepository<UserEf> usersRepository)
        {
            _usersRepository = usersRepository;
        }
        
        public Task<ResponseType1<UserDto>> GetUserById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseType1<UserDto>> GetUserByEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseType1<UserDto>> GetUserByUserName(string userName)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseType1<IEnumerable<UserDto>>> GetUsers()
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

