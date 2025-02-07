using System.Web.Mvc;
using WebProject.App.Services;
using WebProject.Core.DTO.FeedBack.ErrorSuccess;
using WebProject.Core.DTO.User;
using WebProject.Core.Enums.Operation;

namespace WebProject.Controllers
{
    public class HomeController : BaseController
    {
        /*************** Index ***************/
        [HttpGet]
        public ActionResult Index() => View();
        
        
        /// <summary>
        ///  AboutUs page that contains information about the company.
        /// </summary>
        /// <returns> Returns a view. </returns>
        [HttpGet]
        public ActionResult AboutUs() => View();
        
        /// <summary>
        ///  ContactUs page that contains a form to send a message to the company.
        /// </summary>
        /// <returns> Returns a view. </returns>
        [HttpGet]
        public ActionResult ContactUs() => View();

        /// <summary>
        ///  ContactUs page that contains a form to send a message to the company.
        /// </summary>
        /// <param name="contactUsDto"> Gets a model of contact data. </param>
        /// <returns> Returns a view if the model isn't valid and redirects to confirmation action, if is valid. </returns>
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
        
        /// <summary>
        ///  Confirmation page that contains a message of success or error after sending a message or any other operation.
        /// </summary>
        /// <returns> Returns this message to the view. </returns>
        [HttpGet]
        public ActionResult Confirmation()
        {
            var messageResponseDto = TempData["MessageResponse"] as MessageResponseDto 
                                     ?? new MessageResponseDto();

            return View(messageResponseDto);
        }
        
        /// <summary>
        /// The error page that will be shown when an error occurs.
        /// </summary>
        /// <param name="errorCode">It gets the errorCode, initializes an instance of ErrorResponseDto where the error message is already initialized.</param>
        /// <returns>It returns a unified view that contains an error and an error message.</returns>
        [HttpGet]
        public ActionResult Error(int errorCode)
        {
            var errorResponseDto = new ErrorResponseDto(errorCode);
            
            ViewBag.LastUrl = GetLastUrl();

            return View(errorResponseDto);
        }
    }
}