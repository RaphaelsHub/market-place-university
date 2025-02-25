using System.Buffers;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using ECommerce.App.Services.Product;
using ECommerce.Core.Models.DTOs.GenericResponses;
using ECommerce.Core.Models.DTOs.Product;
using OperationStatus = ECommerce.Core.Enums.Request.OperationStatus;

namespace ECommerce.Controllers
{
    public class StoreController : BaseController
    {
        private readonly ProductService _productService;

        public StoreController(ProductService productService)
            => _productService = productService;

        [HttpGet]
        public async Task<ActionResult> Index(string name = "", int categoryId = 0, int page = 1, int itemsPerPage = 10)
        {
            var response = await _productService.GetProductsAsync(name, categoryId, page, itemsPerPage);
            
            if(response.Data==null)
                return Redirect("/Home/Error/500");
            return View(new BaseResponse<List<ProductDto>>(response.Data, OperationStatus.Success, "ok"));
        }

        [HttpGet]
        public async Task<ActionResult> Product(int idProduct)
        {
            var response = await _productService.GetProductByIdAsync(idProduct);
            
            if(response.Data==null)
                return Redirect("/Home/Error/500");
            
            return View(new BaseResponse<ProductDto>(response.Data, OperationStatus.Success, "ok"));
        }
    }
}