using System.Threading.Tasks;
using System.Web.Mvc;
using ECommerce.App.Services.User;
using ECommerce.Core.Constants;
using ECommerce.Core.Models.ViewModels;

namespace ECommerce.Controllers
{
    public class ManagementWebSiteDataController : BaseController
    {
        private readonly ContactUsService _contactUsService;
        
        public ManagementWebSiteDataController(ContactUsService contactUsService) => 
            _contactUsService = contactUsService;
        
        [HttpGet] 
        public ActionResult Index() => View(WebSiteStaticData.GetData());
        
        [HttpPost] 
        public ActionResult Index(WebSiteDataViewModel model)
        {
            if (ModelState.IsValid) 
                WebSiteStaticData.SetData(model);
            
            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> ContactUs(string email = "", int page = 1, int pageSize=20)
        {
            var response = await _contactUsService.GetContactUsRequestsAsync(email,page,pageSize);
            var list = response.Data;
            return View(list);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteData(int id)
        {
           await _contactUsService.DeleteContactUsRequestByIdAsync(id);
           return RedirectToAction("ContactUs", "ManagementWebSiteData");
        }
    }
}
