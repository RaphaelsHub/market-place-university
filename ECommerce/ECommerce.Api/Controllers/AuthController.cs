using System;
using System.Web.Mvc;
using WebProject.App.Interfaces;
using WebProject.Core.DTO.AuthDto;

namespace WebProject.Controllers
{
    public class AuthController : BaseController
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService) => _authService = authService;

        [HttpGet] public ActionResult SignIn() => CheckIfLoggedIn();

        [HttpGet] public ActionResult SignUp() => CheckIfLoggedIn();
        
        [HttpPost] public ActionResult SignIn(SignInDto signInDto)
        {
            if(!ModelState.IsValid)
                return View(signInDto);

            try
            {
                var response = _authService.Login(signInDto);

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
                var response = _authService.Register(signUpDto);

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