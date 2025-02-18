using System.Web.Mvc;
using ECommerce.App.Interfaces.Product;
using ECommerce.Core.Models.DTOs.Product;

namespace ECommerce.Controllers
{
    public class ManagementProductsController : Controller
    {
        private readonly IProductService _storeService;

        public ManagementProductsController(IProductService storeService)
        {
            _storeService = storeService;
        }
        
        [HttpGet] public ActionResult Index(
            string searchByName="", string category ="", string sort="", int page = 1, int usersPerPage= 100) => View();
        
        [HttpGet] public ActionResult ViewProduct(int id) => View();
        
        [HttpPost] public ActionResult AddProduct(ProductDto productDto) => RedirectToAction("Index", "ManagementProducts");
        
        [HttpPost] public ActionResult UpdateProduct(ProductDto productDto) => RedirectToAction("Index", "ManagementProducts");
        
        [HttpPost] public ActionResult DeleteProduct(int idProduct) => RedirectToAction("Index", "ManagementProducts");
    }
}