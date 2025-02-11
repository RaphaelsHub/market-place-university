using System.Threading.Tasks;
using ECommerce.Core.DataTransferObjects.FeedBack.Standard;
using ECommerce.Core.DataTransferObjects.User;

namespace ECommerce.App.Interfaces.User
{
    public interface ICartService 
    {
        Task<ResponseType1<CartDto>> GetCart(int userId); 
        
        // Add and remove from cart
        Task<ResponseType1<bool>> AddToCart(int productId); 
        Task<ResponseType1<bool>> RemoveFromCart(int productId);
        
        // Increase and decrease quantity of product in cart
        Task<ResponseType1<bool>> IncreaseQuantity(int productId);
        Task<ResponseType1<bool>> DecreaseQuantity(int productId);
        
        // Apply promo code
        Task<ResponseType1<bool>> PromoCode(string code);
    }
}