using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.App.Interfaces;
using ECommerce.App.Interfaces.User;
using ECommerce.Core.Entities.User;
using ECommerce.Core.Interfaces.User;
using ECommerce.Core.Models;
using ECommerce.Core.Models.DTOs.ContactUs;
using ECommerce.Core.Models.DTOs.User;
using ECommerce.Core.Models.ViewModels;

namespace ECommerce.App.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUsersRepository _usersRepository;
        
        public UserService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        
        public Task<ResponseViewModel<UserDto>> GetUser(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseViewModel<UserDto>> GetUserByEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseViewModel<UserDto>> GetUserByUserName(string userName)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseViewModel<IEnumerable<UserDto>>> GetUsers()
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
        
        public Task<MessageViewModel> ContactUs(ContactUsDto contactUsDto)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> CreateUserAsync(UserDto user)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseViewModel<UserDto>> GetUserAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseViewModel<UserDto>> FindUserByEmailAsync(string email)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseViewModel<UserDto>> FindUserByUserNameAsync(string userName, int currentPage = 1, int amountOfUsers = 16)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseViewModel<IEnumerable<UserDto>>> GetUsersAsync(int currentPage = 1, int amountOfUsers = 16)
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

