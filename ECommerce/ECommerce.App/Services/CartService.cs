using System.Threading.Tasks;
using ECommerce.App.Interfaces;
using ECommerce.Core.DataTransferObjects.FeedBack.Standard;
using ECommerce.Core.DataTransferObjects.User;
using ECommerce.Core.Entities.Product;
using ECommerce.Core.Entities.User;
using ECommerce.Core.Interfaces.Product;
using ECommerce.Core.Interfaces.User;

namespace ECommerce.App.Services
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
        
        public Task<ResponseType1<CartDto>> GetCart(int userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseType1<bool>> AddToCart(int productId)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseType1<bool>> RemoveFromCart(int productId)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseType1<bool>> IncreaseQuantity(int productId)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseType1<bool>> DecreaseQuantity(int productId)
        {
            throw new System.NotImplementedException();
        }
        
        public Task<ResponseType1<bool>> PromoCode(string code)
        {
            throw new System.NotImplementedException();
        }
    }
}