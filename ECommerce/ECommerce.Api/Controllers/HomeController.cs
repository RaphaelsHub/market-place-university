using System.Threading.Tasks;
using System.Web.Mvc;
using ECommerce.App.Interfaces.Blog;
using ECommerce.App.Interfaces.Product;
using ECommerce.App.Interfaces.User;
using ECommerce.Core.Constants;
using ECommerce.Core.Models.DTOs.ContactUs;
using ECommerce.Core.Models.ViewModels;
using ECommerce.Helper;

namespace ECommerce.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IContactUsService _contactUs;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IBlogService _blogService;
        
        public HomeController(){}
        
        public HomeController(IContactUsService contactUs, IBlogService blogService, 
            ICategoryService categoryService, IProductService productService) 
        {
            _contactUs = contactUs;
            _blogService = blogService;
            _categoryService = categoryService;
            _productService = productService;
        }
        
        [HttpGet]  public ActionResult Index() => View();
        
        [HttpGet] public ActionResult AboutUs() => View();
        
        [HttpGet] public ActionResult ContactUs() => View();
        
        [HttpPost] public async Task<ActionResult> ContactUs(ContactUsDto contactUsDto)
        {
            if (!ModelState.IsValid) return View(contactUsDto);
            
            TempData[TempDataKeys.MessageResponse] = await _contactUs.SendContactUsRequestAsync(contactUsDto);
            
            return RedirectToAction("Confirmation", "Home");
        }
        
        [HttpGet] public ActionResult Confirmation() => (TempData[TempDataKeys.MessageResponse] as MessageViewModel) == null 
            ? (ActionResult)RedirectToAction("Index", "Home") 
            : View(TempData[TempDataKeys.MessageResponse] as MessageViewModel);

        [HttpGet] public ActionResult Error(int? errorCode)
        {
            ViewBag.LastUrl = GetLastUrl();
            return errorCode == null ? 
                View(new ErrorViewModel()) : 
                View(new ErrorViewModel(errorCode.Value,ErrorHelper.GetErrorMessage(errorCode.Value)));
        }
    }
}