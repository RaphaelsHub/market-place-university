using System.Threading.Tasks;
using System.Web.Mvc;
using ECommerce.App.Interfaces.User;
using ECommerce.Core.Enums.Request;

namespace ECommerce.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        
        public CartController(ICartService cartService) =>
            _cartService = cartService;

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var response = await _cartService.GetCart();
            if (response.Status == OperationStatus.Error)
                return Redirect("/Home/Error/500");
            
            return View(response.Data);
        }

        [HttpPost]
        public async Task<ActionResult> IncreaseQuantity(int idProduct)
        {
            var response = await _cartService.IncreaseQuantity(idProduct);
            return Json(response.Status != OperationStatus.Error);
        }

        [HttpPost]
        public async Task<ActionResult> DecreaseQuantity(int idProduct)
        {
            var response = await _cartService.DecreaseQuantity(idProduct);
            return Json(response.Status != OperationStatus.Error);
        }

        [HttpPost]
        public async Task<ActionResult> AddItem(int idProduct)
        {
            var response = await _cartService.AddToCartByProductId(idProduct);
            return Json(response.Status != OperationStatus.Error);
        }
        
        [HttpPost]
        public async Task<ActionResult> RemoveItem(int idProduct)
        {
            var response = await _cartService.RemoveFromCart(idProduct);
            return Json(response.Status != OperationStatus.Error);
        }
    }
}