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
        [HttpGet] public ActionResult ContactUs() => View();
    }
}
