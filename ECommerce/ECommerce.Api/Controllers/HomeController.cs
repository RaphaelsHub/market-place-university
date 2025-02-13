using System.Web.Mvc;
using ECommerce.App.Interfaces;
using ECommerce.App.Interfaces.User;
using ECommerce.Core.Constants;
using ECommerce.Core.DataTransferObjects.Responses;
using ECommerce.Core.DataTransferObjects.User;

namespace ECommerce.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IUserService _userService;
        
        public HomeController() { }
        public HomeController(IUserService userService) => _userService = userService;
        
        [HttpGet] public ActionResult Index() => View();
        
        [HttpGet] public ActionResult AboutUs() => View();
        
        [HttpGet] public ActionResult ContactUs() => View();
        
        [HttpPost] public ActionResult ContactUs(ContactUsDto contactUsDto)
        {
            if (!ModelState.IsValid) 
                return View(contactUsDto);
            
            //TempData["MessageResponse"] = _userService.ContactUs(contactUsDto).Result;
            
            return RedirectToAction("Confirmation");
        }
        
        [HttpGet] public ActionResult Confirmation()
        {
            var messageResponseDto = TempData["MessageResponse"] as MessageResponseDto 
                                     ?? new MessageResponseDto();

            return View(messageResponseDto);
        }
        
        [HttpGet] public ActionResult Error(int errorCode, string errorMessage)
        {
            var errorResponseDto = new ErrorResponseDto(errorCode, errorMessage);
            
            ViewBag.LastUrl = GetLastUrl();

           return View(errorResponseDto);
        }
    }
}