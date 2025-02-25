using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.Core.Enums.User;
using ECommerce.Core.Models.DTOs.GenericResponses;
using ECommerce.Core.Models.DTOs.User;

namespace ECommerce.App.Interfaces.User
{
    public interface IUserService
    {
        Task<BaseResponse<UserDto>> CreateUserAsync(SignUpDto signUpDto);
        Task<BaseResponse<UserDto>> UpdateUserAsync(UserDto userDto);
        Task<BaseResponse<bool>> DeleteUserByIdAsync(int id);
        Task<BaseResponse<UserDto>> GetUserByIdAsync(int id);
        Task<BaseResponse<UserDto>> GetUserByEmailAsync(string email);
        Task<BaseResponse<List<UserDto>>> GetUsersAsync(string email, UserType userType , int currentPage , int amountOfUsers); 
    }
}