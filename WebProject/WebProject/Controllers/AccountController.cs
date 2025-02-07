using System;
using System.Web.Mvc;
using WebProject.App.Interfaces;
using WebProject.Core.DTO.User;

namespace WebProject.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        public AccountController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }
        
        
        /************** Sign In **************/
        [HttpGet]
        public ActionResult SignIn() => View();
        
        [HttpPost]
        public ActionResult SignIn(SignInDto loginDto)
        {
            if(!ModelState.IsValid)
                return View(loginDto);

            try
            {
                var response = _authService.Login(loginDto);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("Error", e.Message);
                return View(loginDto);
            }
            
            return RedirectToAction("Index", "Home");
        }
        
        
        /************** Sign Up **************/
        [HttpGet]
        public ActionResult SignUp() => View();
     
        [HttpPost]
        public ActionResult SignUp(SignUpDto registerDto)
        {
            if(!ModelState.IsValid)
                return View(registerDto);

            try
            {
                var response = _authService.Register(registerDto);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("Error", e.Message);
                return View(registerDto);
            }
            
            return RedirectToAction("Index", "Home");
        }
        
        
        /************** Sign Out **************/
        [HttpGet]
        public ActionResult SignOut()
        {
            var response = _authService.Logout();
            
            return RedirectToAction("Index", "Home");
        }


        

        
        
        // User Admin Actions
        [HttpGet]
        public ActionResult Users()
        {
            _userService.GetUsers();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult FindUser(string search)
        {
            _userService.GetUserByUserName(search);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult AddUser()
        {
            _userService.AddUser(new UserDto());
            return RedirectToAction("Users");
        }
        
        [HttpPatch]
        public ActionResult UpdateUser()
        {
            _userService.UpdateUser(new UserDto());
            return RedirectToAction("Users");
        }

        [HttpDelete]
        public ActionResult DeleteUser()
        {
            _userService.DeleteUser(new UserDto());
            return RedirectToAction("Users");
        }
    }
}