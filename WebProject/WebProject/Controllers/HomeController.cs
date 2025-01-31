using System.Web.Mvc;
using WebProject.Core.DTO.ResponcesDto;
using WebProject.Core.DTO.UserDtoS;

namespace WebProject.Controllers
{
    public class HomeController : BaseController
    {
        /*************** Index ***************/
        [HttpGet]
        public ActionResult Index() => View();
        
        
        /************** AboutUs **************/
        [HttpGet]
        public ActionResult AboutUs() => View();
        
        /************* ContactUs *************/
        [HttpGet]
        public ActionResult ContactUs() => View();

        [HttpPost]
        public ActionResult ContactUs(ContactUsDto contactUsDto)
        {
            if (!ModelState.IsValid) 
                return View(contactUsDto);

            TempData["MessageResponse"] = new MessageResponseDto(
                "Message sent successfully, soon we will get in touch !", 
                "Success",
                1);
            
            return RedirectToAction("Thanks");
        }

        
        /************** Thanks **************/
        [HttpGet]
        public ActionResult Thanks()
        {
            var messageResponseDto = TempData["MessageResponse"] as MessageResponseDto;
            
            if (messageResponseDto == null)
                View(new MessageResponseDto());
            
            return View(messageResponseDto);
        }
        
        
        /************** GetDiscount **************/
        [HttpPost]
        public ActionResult GetDiscount(EmailUserDto emailUserDto)
        {
            if (!ModelState.IsValid) 
                return RedirectToAction(GetLastUrl());
            
            TempData["MessageResponse"] = new MessageResponseDto(
                "Discount promo-code sent successfully, check your email !", 
                "Success",
                1);
            
            return RedirectToAction("Thanks");
        }
        
        
        /************** Error **************/
        [HttpGet]
        public ActionResult Error(int? statusCode)
        {
            var code = statusCode ?? 500;

            var errorMessageResponseDto = new ErrorMessageResponse(code);

            ViewBag.LastUrl = GetLastUrl();

            return View(errorMessageResponseDto);
        }
    }
}