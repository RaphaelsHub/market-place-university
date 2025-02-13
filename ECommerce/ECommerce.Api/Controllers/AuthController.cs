using System;
using System.Web.Mvc;
using ECommerce.App.Interfaces.Auth;
using ECommerce.App.Services.Auth;
using ECommerce.Core.DataTransferObjects.AuthDto;
using ECommerce.Core.DataTransferObjects.Responses;

namespace ECommerce.Controllers
{
    public class AuthController : BaseController
    {
        private readonly IAuthenticationService _authService;
        public AuthController(IAuthenticationService  authService) => _authService = authService;

        [HttpGet] public ActionResult SignIn() => View();

        [HttpGet] public ActionResult SignUp() => View();
        
        [HttpPost] public ActionResult SignIn(SignInDto signInDto)
        {
            if(!ModelState.IsValid)
                return View(signInDto);

            try
            {
                var response = _authService.SignIn(signInDto);

                if (response.Result.Data == false)
                {
                    TempData["Error"] = response.Result.Message;
                    return View(signInDto);
                }
                return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Home", new {errorCode = 500, errorMessage = e.Message});
            }
        }
        
        [HttpPost] public ActionResult SignUp(SignUpDto signUpDto)
        {
            if(!ModelState.IsValid)
                return View(signUpDto);

            try
            {
                var response = _authService.SignUp(signUpDto);

                if (response.Result.Data == false)
                {
                    TempData["Error"] = response.Result.Message;
                    return View(signUpDto);
                }
                return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Home", new {errorCode = 500, errorMessage = e.Message});
            }
        }
        
        [HttpGet] public ActionResult SignOut()
        {
            try
            {
                var response = _authService.Logout();
                
                if (response.Result.Data == false)
                    return RedirectToAction("Error", "Home", 
                        new {errorCode = 500, errorMessage = response.Result.Message});
                
                return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Home", new {errorCode = 500, errorMessage = e.Message});
            }
        }
    }
}