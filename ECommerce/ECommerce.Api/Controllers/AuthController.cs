using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using ECommerce.App.Interfaces.Auth;
using ECommerce.App.Interfaces.JWT;
using ECommerce.Core.Constants;
using ECommerce.Core.DataTransferObjects.AuthDto;
using ECommerce.Core.DataTransferObjects.Responses;

namespace ECommerce.Controllers
{
    public class AuthController : BaseController
    {
        private readonly IAuthenticationService _authService;
        private readonly IJwtService _jwtService;

        public AuthController(IAuthenticationService authService, IJwtService jwtService)
        {
            _authService = authService;
            _jwtService = jwtService;
        }

        [HttpGet]
        public async Task<ActionResult> SignIn() => await _jwtService.IsTokenValid()
            ? (ActionResult)RedirectToAction("Index", "Home")
            : View();
        
        [HttpGet] public async Task<ActionResult> SignUp() => await _jwtService.IsTokenValid()
            ? (ActionResult)RedirectToAction("Index", "Home")  
            : View();
    
        [HttpPost] public async Task<ActionResult> SignIn(SignInDto signInDto) => 
            await ProcessAuthentication(async () => await _authService.SignIn(signInDto), signInDto);
        
        [HttpPost] public async Task<ActionResult> SignUp(SignUpDto signUpDto) => 
            await ProcessAuthentication(async () => await _authService.SignUp(signUpDto), signUpDto);

        [HttpGet] public async Task<ActionResult> SignOut()
        {
            try
            {
                var response = await _authService.Logout();

                if (!response.Data)
                    return RedirectToErrorPage(500);

                return RedirectToAction("SignIn", "Auth");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error has occured : {e.Message}");
                return RedirectToErrorPage(500);
            }
        }

        private async Task<ActionResult> ProcessAuthentication
            (Func<Task<ResponseType1<bool>>> authServiceMethod, object dto)
        {
            if (await _jwtService.IsTokenValid())
                return RedirectToAction("Index", "Home");

            if (!ModelState.IsValid)
                return View(dto);

            try
            {
                var response = await authServiceMethod();

                if (!response.Data)
                {
                    TempData[TempDataKeys.Error] = response.Message;
                    return View(dto);
                }
                return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error has occured : {e.Message}");
                return RedirectToErrorPage(500);
            }
        }
    }
}
