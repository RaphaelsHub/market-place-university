using System.Linq;
using System.Threading.Tasks;
using ECommerce.App.Interfaces.JWT;
using ECommerce.App.Interfaces.User;
using ECommerce.Core.Entities.Product;
using ECommerce.Core.Entities.User;
using ECommerce.Core.Enums.Request;
using ECommerce.Core.Interfaces.Product;
using ECommerce.Core.Interfaces.User;
using ECommerce.Core.Models.DTOs.Cart;
using ECommerce.Core.Models.DTOs.GenericResponses;
using ECommerce.Core.Models.DTOs.Product;
using ExpressMapper;

namespace ECommerce.App.Services.User
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductsRepository _productsRepository;
        private readonly IJwtService _jwtService;
        private readonly IUsersRepository _usersRepository;
        
        public CartService(ICartRepository cartRepository, IProductsRepository productsRepository, IUsersRepository usersRepository, IJwtService jwtService)
        {
            _cartRepository = cartRepository;
            _productsRepository = productsRepository;
            _jwtService = jwtService;
            _usersRepository = usersRepository;
        }
        
        public async Task<BaseResponse<CartDto>> GetCart()
        {
            var userId = await _jwtService.GetUserIdFromToken();
            var cart = await _cartRepository.GetCartByUserIdAsync(userId);

            if (cart == null)
            {
                return new BaseResponse<CartDto>(null, OperationStatus.Error, "Cart not found");
            }

            var cartItems = cart.Select(cartItem => new CartItemDto()
            {
                Product = Mapper.Map<ProductEf, ProductDto>(_productsRepository.GetByIdAsync(cartItem.ProductId).Result),
                Quantity = cartItem.Quantity
            }).ToList();

            var cartDto = new CartDto(cartItems);
            return new BaseResponse<CartDto>(cartDto, OperationStatus.Success, "Cart retrieved successfully");
        }

        public async Task<BaseResponse<bool>> AddToCartByProductId(int productId)
        {
            var userId = await _jwtService.GetUserIdFromToken();
            var cartItem = GetCartItemEf(productId, userId);

            var result = await _cartRepository.AddToCartAsync(userId, cartItem);

            return new BaseResponse<bool>(result != null, OperationStatus.Success, "Product added to cart successfully");
        }

        public async Task<BaseResponse<bool>> RemoveFromCart(int productId)
        {
            var userId = await _jwtService.GetUserIdFromToken();
            var success = await _cartRepository.RemoveFromCartAsync(userId, productId);

            return new BaseResponse<bool>(success, OperationStatus.Success, success ? "Product removed from cart successfully" : "Product not found in cart");
        }

        public async Task<BaseResponse<bool>> IncreaseQuantity(int productId)
        {
            var userId = await _jwtService.GetUserIdFromToken();
            var cartItem = GetCartItemEf(productId, userId);
            cartItem.Quantity = 1;

            var result = await _cartRepository.UpdateCartAsync(userId, cartItem);
            return new BaseResponse<bool>(result != null, OperationStatus.Success, "Quantity increased successfully");
        }

        public async Task<BaseResponse<bool>> DecreaseQuantity(int productId)
        {
            var userId = await _jwtService.GetUserIdFromToken();
            var cartItem = GetCartItemEf(productId, userId);
            cartItem.Quantity = -1;

            var result = await _cartRepository.UpdateCartAsync(userId, cartItem);
            return new BaseResponse<bool>(result != null, OperationStatus.Success, "Quantity decreased successfully");
        }

        private CartItemEf GetCartItemEf(int productId, int userId)
        {
            return new CartItemEf()
            {
                ProductId = productId,
                UserId = userId
            };
        }
    }
}
