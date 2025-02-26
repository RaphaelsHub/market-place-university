using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using ECommerce.App.Interfaces.Blog;
using ECommerce.App.Interfaces.Product;
using ECommerce.App.Interfaces.User;
using ECommerce.Core.Constants;
using ECommerce.Core.Models.DTOs.Blog;
using ECommerce.Core.Models.DTOs.Contact;
using ECommerce.Core.Models.DTOs.Product;
using ECommerce.Core.Models.ViewModels;
using ECommerce.Helper;


namespace ECommerce.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IBlogService _blogService;
        private readonly IContactUsService _contactUs;
        
        public HomeController(){}
        public HomeController(ICategoryService categoryService, IProductService productService, IBlogService blogService, IContactUsService contactUs)
        {
            _categoryService = categoryService;
            _productService = productService;
            _blogService = blogService;
            _contactUs = contactUs;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var responseBlogs = await _blogService.GetLatestBlogsAsync(8);
            var responseProducts = await _productService.GetProductsByMostViewedAsync(8);
            var responseProducts1 = await _productService.GetProductsByMostViewedAsync(16);
            var viewModel = new ComplexDataViewModel<List<BlogDto>,List<ProductDto>,List<ProductDto>>(responseBlogs.Data.ToList(), responseProducts.Data, responseProducts1.Data);
            return View(viewModel);
        }
        
        [HttpGet] 
        public ActionResult AboutUs() => View();
        
        [HttpGet] 
        public ActionResult ContactUs() => View();
        
        [HttpPost] 
        public async Task<ActionResult> ContactUs(ContactUsDto contactUsDto)
        {
            if (!ModelState.IsValid) 
                return View(contactUsDto);
            
            TempData[TempDataKeys.ConfirmationMessageResponse] = await 
                _contactUs.CreateContactUsRequestAsync(contactUsDto);
            
            return Redirect("/Home/Confirmation");
        }
        
        [HttpGet] 
        public ActionResult Confirmation()
        {
            var model = TempData[TempDataKeys.ConfirmationMessageResponse] as ConfirmationViewModel;
            return model == null ? 
                (ActionResult)Redirect("/Home/Index") : 
                View(model);
        }

        [HttpGet] 
        public ActionResult Error(int errorCode)
        {
            ViewBag.LastUrl = GetLastUrl();
            return View(new ErrorViewModel(errorCode, ErrorHelper.GetErrorMessage(errorCode)));
        }
    }
}