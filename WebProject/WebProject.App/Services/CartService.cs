using System.Threading.Tasks;
using WebProject.App.Interfaces;
using WebProject.Core.DTO;
using WebProject.Core.DTO.FeedBack.Standard;

namespace WebProject.App.Services
{
    public class CartService : ICartService
    {
        public Task<Response<CartDto>> GetCart(int userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<bool>> AddToCart(int productId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<bool>> RemoveFromCart(int productId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<bool>> IncreaseQuantity(int productId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<bool>> DecreaseQuantity(int productId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<bool>> PromoCode(string code)
        {
            throw new System.NotImplementedException();
        }
    }
}