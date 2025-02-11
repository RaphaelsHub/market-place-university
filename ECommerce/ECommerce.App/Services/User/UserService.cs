using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.App.Interfaces;
using ECommerce.App.Interfaces.User;
using ECommerce.Core.DataTransferObjects.FeedBack.ErrorSuccess;
using ECommerce.Core.DataTransferObjects.FeedBack.Standard;
using ECommerce.Core.DataTransferObjects.User;
using ECommerce.Core.Entities.User;
using ECommerce.Core.Interfaces.User;

namespace ECommerce.App.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUsersRepository<UserEf> _usersRepository;
        
        public UserService(IUsersRepository<UserEf> usersRepository)
        {
            _usersRepository = usersRepository;
        }
        
        public Task<ResponseType1<UserDto>> GetUser(int id)
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

        public Task<bool> CreateUser(UserDto user)
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
        
        public Task<MessageResponseDto> ContactUs(ContactUsDto contactUsDto)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> CreateUserAsync(UserDto user)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseType1<UserDto>> GetUserAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseType1<UserDto>> FindUserByEmailAsync(string email)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseType1<UserDto>> FindUserByUserNameAsync(string userName, int currentPage = 1, int amountOfUsers = 16)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseType1<IEnumerable<UserDto>>> GetUsersAsync(int currentPage = 1, int amountOfUsers = 16)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateUserAsync(UserDto user)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteUserAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}

