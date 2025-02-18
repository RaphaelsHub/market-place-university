using System.Web.Mvc;
using ECommerce.Core.Constants;
using ECommerce.Core.Models.ViewModels;

namespace ECommerce.Controllers
{
    public class ManagementWebSiteDataController : BaseController
    {
        [HttpGet] public ActionResult Index() => View(WebSiteStaticData.GetData(new WebSiteDataViewModel()));
        [HttpPost] public ActionResult Index(WebSiteDataViewModel model)
        {
            if (ModelState.IsValid) WebSiteStaticData.SetData(model);
            
            return View(model);
        }
        [HttpGet] public ActionResult ContactUs() => View();
    }
}
