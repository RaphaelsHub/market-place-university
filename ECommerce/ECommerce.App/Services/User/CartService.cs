using System.Threading.Tasks;
using ECommerce.App.Interfaces.User;
using ECommerce.Core.Entities.Product;
using ECommerce.Core.Entities.User;
using ECommerce.Core.Interfaces.Product;
using ECommerce.Core.Interfaces.User;
using ECommerce.Core.Models;
using ECommerce.Core.Models.ViewModels;

namespace ECommerce.App.Services.User
{
    public class CartService : ICartService
    {
        private readonly ICartItemsRepository<CartItemEf> _cartItemsRepository;
        private readonly IProductsRepository<ProductEf> _productsRepository;
        
        public CartService(ICartItemsRepository<CartItemEf> cartItemsRepository, IProductsRepository<ProductEf> productsRepository)
        {
            _cartItemsRepository = cartItemsRepository;
            _productsRepository = productsRepository;
        }
        
        public Task<ResponseViewModel<CartDto>> GetCart(int userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseViewModel<bool>> AddToCart(int productId)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseViewModel<bool>> RemoveFromCart(int productId)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseViewModel<bool>> IncreaseQuantity(int productId)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseViewModel<bool>> DecreaseQuantity(int productId)
        {
            throw new System.NotImplementedException();
        }
        
        public Task<ResponseViewModel<bool>> PromoCode(string code)
        {
            throw new System.NotImplementedException();
        }
    }
}