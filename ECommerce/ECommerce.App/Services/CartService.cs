using System.Threading.Tasks;
using WebProject.App.Interfaces;
using WebProject.Core.DTO;
using WebProject.Core.DTO.FeedBack.Standard;
using WebProject.Core.DTO.User;
using WebProject.Core.Entities.Product;
using WebProject.Core.Entities.User;
using WebProject.Core.Interfaces.Product;
using WebProject.Core.Interfaces.User;

namespace WebProject.App.Services
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