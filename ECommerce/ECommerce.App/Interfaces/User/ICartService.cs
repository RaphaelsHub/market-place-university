using System.Threading.Tasks;
using ECommerce.Core.Models;
using ECommerce.Core.Models.ViewModels;

namespace ECommerce.App.Interfaces.User
{
    public interface ICartService 
    {
        Task<ResponseViewModel<CartDto>> GetCart(int userId); 
        
        // Add and remove from cart
        Task<ResponseViewModel<bool>> AddToCart(int productId); 
        Task<ResponseViewModel<bool>> RemoveFromCart(int productId);
        
        // Increase and decrease quantity of product in cart
        Task<ResponseViewModel<bool>> IncreaseQuantity(int productId);
        Task<ResponseViewModel<bool>> DecreaseQuantity(int productId);
        
        // Apply promo code
        Task<ResponseViewModel<bool>> PromoCode(string code);
    }
}