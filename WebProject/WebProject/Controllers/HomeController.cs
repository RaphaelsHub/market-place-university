using System.Web.Mvc;
using WebProject.Core.DTO.FeedBack.Error;
using WebProject.Core.DTO.FeedBack.Standart;
using WebProject.Core.DTO.User;
using WebProject.Core.Enums.Operation;

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
                1,
                "Message sent successfully, we will contact you soon !",
                RequestStatus.Success);
            
            return RedirectToAction("Confirmation");
        }

        
        /************** Thanks **************/
        [HttpGet]
        public ActionResult Confirmation()
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
                1,
                "Discount code sent to your email successfully !",
                RequestStatus.Success);
            
            return RedirectToAction("Confirmation");
        }
        
        
        /************** Error **************/
        [HttpGet]
        public ActionResult Error(int? statusCode)
        {
            var code = statusCode ?? 500;

            var errorMessageResponseDto = new ErrorResponseDto(code);

            ViewBag.LastUrl = GetLastUrl();

            return View(errorMessageResponseDto);
        }
    }
}