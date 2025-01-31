using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        public ActionResult GetDiscount(string email) => RedirectToAction(GetLastUrl());
    }
}