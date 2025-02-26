using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using ECommerce.App.Interfaces.User;
using ECommerce.Core.Constants;
using ECommerce.Core.Models.DTOs.GenericResponses;
using ECommerce.Core.Models.DTOs.User;

namespace ECommerce.Controllers
{
    public class AuthController : BaseController
    {
        private readonly IAuthenticationService _authService;

        public AuthController(IAuthenticationService authService) =>
            _authService = authService;

        [HttpGet]
        public async Task<ActionResult> SignIn() => await CheckTokenValidity();

        [HttpGet]
        public async Task<ActionResult> SignUp() => await CheckTokenValidity();

        [HttpPost]
        public async Task<ActionResult> SignIn(SignInDto signInDto) =>
            await ProcessAuthentication(async () => await _authService.SignIn(signInDto), signInDto);

        [HttpPost]
        public async Task<ActionResult> SignUp(SignUpDto signUpDto) =>
            await ProcessAuthentication(async () => await _authService.SignUp(signUpDto), signUpDto);

        [HttpGet]
        public async Task<ActionResult> SignOut()
        {
            await _authService.Logout();
            return Redirect("/Home/Index");
        }

        private async Task<ActionResult> ProcessAuthentication
            (Func<Task<BaseResponse<bool>>> authServiceMethod, object dto)
        {
            var tokenResponse = await _authService.IsTokenValid();

            if (tokenResponse.Data) return RedirectToAction("Index", "Home");

            if (!ModelState.IsValid) return View(dto);

            var authResponse = await authServiceMethod();

            if (!authResponse.Data)
            {
                TempData[TempDataKeys.Error] = authResponse.Message;
                return View(dto);
            }

            return RedirectToAction("Index", "Home");
        }

        private async Task<ActionResult> CheckTokenValidity()
        {
            var response = await _authService.IsTokenValid();
            if (response.Data)
                return Redirect("/Home/Index");
            return View();
        }
    }
}