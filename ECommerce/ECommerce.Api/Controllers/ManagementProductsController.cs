using System.Threading.Tasks;
using System.Web.Mvc;
using ECommerce.App.Interfaces.Product;
using ECommerce.Core.Enums.Request;
using ECommerce.Core.Models.DTOs.GenericResponses;
using ECommerce.Core.Models.DTOs.Product;

namespace ECommerce.Controllers
{
    public class ManagementProductsController : Controller
    {
        private readonly IProductService _productService;

        public ManagementProductsController(IProductService storeService)
        {
            _productService = storeService;
        }
        
        [HttpGet] public ActionResult Index(
            string searchByName="", string category ="", string sort="", int page = 1, int usersPerPage= 100) => View();

        [HttpGet]
        public async Task<ActionResult> ViewProduct(int id)
        {
            var response = await _productService.GetProductByIdAsync(id);
            
            if(response.Data==null)
                return Redirect("/Home/Error/500");
            
            return View(new BaseResponse<ProductDto>(response.Data, OperationStatus.Success, "ok"));
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct(ProductDto productDto)
        {
            var response = await _productService.CreateProductAsync(productDto);
            
            if(response.Data==null)
                return Redirect("/Home/Error/500");
            
            return RedirectToAction("ViewProduct","ManagementProducts", new {id = response.Data.ProductId});
        }

        [HttpPost]
        public async Task<ActionResult> UpdateProduct(ProductDto productDto)
        {
            var response = await _productService.UpdateProductAsync(productDto);
            
            if(response.Data==null)
                return Redirect("/Home/Error/500");
            
            return RedirectToAction("ViewProduct","ManagementProducts", new {id = response.Data.ProductId});
        }

        [HttpPost]
        public async Task<ActionResult> DeleteProduct(int idProduct)
        {
            var response =await _productService.DeleteProductByIdAsync(idProduct);
            
            if(!response.Data)
                return Redirect("/Home/Error/500");
            
            return RedirectToAction("Index","ManagementProducts");
        }
    }
}