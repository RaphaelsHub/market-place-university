using System;
using System.Threading.Tasks;
using ECommerce.App.Infrastructure.Abstractions;
using ECommerce.App.Interfaces.JWT;
using ECommerce.App.Interfaces.User;
using ECommerce.Core.Entities.User;
using ECommerce.Core.Enums.Request;
using ECommerce.Core.Interfaces.User;
using ECommerce.Core.Models.DTOs.GenericResponses;
using ECommerce.Core.Models.DTOs.User;
using ECommerce.Helper;
using ExpressMapper;

namespace ECommerce.App.Services.User
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IJwtService _jwtService;
        private readonly ICookiesService _cookiesService;
        private readonly IUserService _userService;
        
        public AuthenticationService(IUsersRepository usersRepository, ICookiesService cookiesService, IJwtService jwtService, IUserService userService)
        {
            _usersRepository = usersRepository;
            _cookiesService = cookiesService;
            _jwtService = jwtService;
            _userService = userService;
        }

        public async Task<BaseResponse<bool>> SignUp(SignUpDto registrationDto)
        {
            var response = await _userService.CreateUserAsync(registrationDto);

            if (response.Data == null || response.Status != OperationStatus.Success)
                return new BaseResponse<bool>(false,response.Status, response.Message);
            
            var token =await _jwtService.GenerateToken(response.Data);
            
            _cookiesService.SetCookie("jwt", token, DateTime.Now.AddHours(1));
            
            return  new BaseResponse<bool>(true, response.Status,"User signed up successfully");
        }

        public async Task<BaseResponse<bool>> SignIn(SignInDto loginDto)
        {
            var user = await _usersRepository.GetByEmailAsync(loginDto.Email);
            
            if (user == null || !HashingUtility.VerifyPasswordSha256(loginDto.Password, user.PasswordHash))
                return new BaseResponse<bool>(false, OperationStatus.Error, "Email or password is incorrect.");
            
            var mappedUser = Mapper.Map<UserEf, UserDto>(user);
            
            var token = await _jwtService.GenerateToken(mappedUser);
            
            _cookiesService.SetCookie("jwt", token, DateTime.Now.AddHours(1));
            
            return new BaseResponse<bool>(true, OperationStatus.Success, "User signed in successfully");
        }

        public async Task<BaseResponse<bool>> IsTokenValid()
        {
            return await _jwtService.IsTokenValid() ? 
                new BaseResponse<bool>(true, OperationStatus.Success, "Token is valid") : 
                new BaseResponse<bool>(false, OperationStatus.Error, "Token is invalid");
        }

        public async Task<BaseResponse<bool>> Logout()
        {
            _cookiesService.DeleteCookie("jwt");
            return  new BaseResponse<bool>(true, OperationStatus.Success, "User signed out successfully");
        }

        public Task<BaseResponse<bool>> SendEmailConfirmation(string email)
        {
            throw new NotImplementedException();
        }
    }
}