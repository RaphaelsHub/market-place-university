using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.App.Interfaces;
using ECommerce.Core.DataTransferObjects.FeedBack.Standard;
using ECommerce.Core.DataTransferObjects.User;
using ECommerce.Core.Entities.User;
using ECommerce.Core.Interfaces.User;

namespace ECommerce.App.Services
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

