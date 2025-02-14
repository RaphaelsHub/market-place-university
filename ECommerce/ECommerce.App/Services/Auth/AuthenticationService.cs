using System;
using System.Threading.Tasks;
using System.Web;
using ECommerce.App.Infrastructure.Abstractions;
using ECommerce.App.Interfaces.Auth;
using ECommerce.App.Interfaces.JWT;
using ECommerce.Core.DataTransferObjects.AuthDto;
using ECommerce.Core.DataTransferObjects.Responses;
using ECommerce.Core.Entities.User;
using ECommerce.Core.Interfaces.User;
using ECommerce.Helper;

namespace ECommerce.App.Services.Auth
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IJwtService _jwtService;
        private readonly ICookiesService _cookiesService;
        
        public AuthenticationService(IUsersRepository usersRepository, ICookiesService cookiesService, IJwtService jwtService)
        {
            _usersRepository = usersRepository;
            _cookiesService = cookiesService;
            _jwtService = jwtService;
        }

        public async Task<ResponseType1<bool>> SignUp(SignUpDto registrationDto)
        {
            var user = await _usersRepository.GetByEmailAsync(registrationDto.Email);
            
            if (user != null)
                return new ResponseType1<bool>(false, "User with this email already exists");
            
            var newUser = new UserEf
            {
                Name = registrationDto.Name,
                Email = registrationDto.Email,
                PasswordHash = HashingUtility.HashPasswordSha256(registrationDto.Password),
                IsSignUpForNewsletter = registrationDto.SignUpForNewsletter,
                IpAddress = HttpContext.Current.Request.UserHostAddress
            };

            await _usersRepository.CreateAsync(newUser);

            var user2 = await _usersRepository.GetByEmailAsync(registrationDto.Email);
            
            var token = _jwtService.GenerateToken(user2);
            
            await _cookiesService.SetCookie("jwt", token, DateTime.Now.AddHours(1));
            
            return new ResponseType1<bool>(true, "User created successfully");
        }

        public async Task<ResponseType1<bool>> SignIn(SignInDto loginDto)
        {
            var user = await _usersRepository.GetByEmailAsync(loginDto.Email);
            
            if (user == null || !HashingUtility.VerifyPasswordSha256(loginDto.Password, user.PasswordHash))
                return new ResponseType1<bool>(false, "Email or password is incorrect.");
            

            
            var token = _jwtService.GenerateToken(user);
            
            await _cookiesService.SetCookie("jwt", token, DateTime.Now.AddHours(1));

            return new ResponseType1<bool>(true, "User signed in successfully");
        }

        public async Task<ResponseType1<bool>> Logout()
        {
            await _cookiesService.DeleteCookie("jwt");
            return new ResponseType1<bool>(true, "User signed out successfully");
        }

        public Task<ResponseType1<bool>> SendEmailConfirmation(string email)
        {
            throw new NotImplementedException();
        }
    }
}