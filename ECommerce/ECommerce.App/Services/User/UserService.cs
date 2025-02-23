using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.App.Interfaces.User;
using ECommerce.Core.Entities.User;
using ECommerce.Core.Enums.Request;
using ECommerce.Core.Enums.User;
using ECommerce.Core.Interfaces.User;
using ECommerce.Core.Models.DTOs.GenericResponses;
using ECommerce.Core.Models.DTOs.User;
using ExpressMapper; 

namespace ECommerce.App.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUsersRepository _usersRepository;
        public UserService(IUsersRepository usersRepository) 
            => _usersRepository = usersRepository;
        
        public async Task<BaseResponse<UserDto>> CreateUserAsync(SignUpDto signUpDto)
        {
            var response = await GetUserByEmailAsync(signUpDto.Email);
            
            if(response.Data != null)
                return new BaseResponse<UserDto>(null, OperationStatus.Error, "User with this email already exists");
            
            var userEf = Mapper.Map<SignUpDto, UserEf>(signUpDto);
            
            var userEfFromDb = await _usersRepository.CreateAsync(userEf);
            
            return userEfFromDb == null ?
                new BaseResponse<UserDto>(null, OperationStatus.Error, "User not created") :
                new BaseResponse<UserDto>(Mapper.Map<UserEf, UserDto>(userEfFromDb), OperationStatus.Success, "User Created");
        }
        
        public async Task<BaseResponse<UserDto>> GetUserByIdAsync(int id)
        {
            var userEf = await _usersRepository.GetByIdAsync(id);
            
            return userEf == null ? 
                new BaseResponse<UserDto>(null, OperationStatus.Error, "User not found") : 
                new BaseResponse<UserDto>(Mapper.Map<UserEf, UserDto>(userEf), OperationStatus.Success, "User got by id");
        }

        public async Task<BaseResponse<UserDto>> GetUserByEmailAsync(string email)
        {
            var userEf = await _usersRepository.GetByEmailAsync(email);
            
            return  userEf == null ? 
                new BaseResponse<UserDto>(null, OperationStatus.Error, "User not found") : 
                new BaseResponse<UserDto>(Mapper.Map<UserEf, UserDto>(userEf), OperationStatus.Success, "User got by email");
        }

        public async Task<BaseResponse<List<UserDto>>> GetUsersAsync(string searchByEmail, UserType userType, int currentPage, int amountOfUsers)
        {
            var userEfs = (await _usersRepository.GetPaginatedUsersByEmailAndTypeAsync(searchByEmail, userType, currentPage, amountOfUsers)).ToList();
            
            return !userEfs.Any() ? 
                new BaseResponse<List<UserDto>>(null, OperationStatus.Success, "Users not found") : 
                new BaseResponse<List<UserDto>>(userEfs.Select(Mapper.Map<UserEf, UserDto>).ToList(), OperationStatus.Success, "Users got");
        }
        
        public async Task<BaseResponse<UserDto>> UpdateUserAsync(UserDto userDto)
        {
            var userEf = Mapper.Map<UserDto, UserEf>(userDto);
            
            var userEfFromDb = await _usersRepository.UpdateAsync(userEf);
            
            return  userEfFromDb == null ? 
                new BaseResponse<UserDto>(null, OperationStatus.Error, "User not Updated") :
                new BaseResponse<UserDto>(Mapper.Map<UserEf, UserDto>(userEfFromDb), OperationStatus.Success, "User Updated");
        }

        public async Task<BaseResponse<bool>> DeleteUserByIdAsync(int id)
        {
            await _usersRepository.DeleteByIdAsync(id);
            
            return new BaseResponse<bool>(true, OperationStatus.Success, "User Deleted");
        }
    }
}

