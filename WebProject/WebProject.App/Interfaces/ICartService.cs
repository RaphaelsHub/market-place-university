using WebProject.Core.DTO;
using System.Threading.Tasks;
using WebProject.Core.DTO.FeedBack.Standard;
using WebProject.Core.DTO.ResponcesDto;


namespace WebProject.App.Interfaces
{
    public interface ICartService 
    {
        Task<Response<CartDto>> GetCart(int userId); 
        
        // Add and remove from cart
        Task<Response<bool>> AddToCart(int productId); 
        Task<Response<bool>> RemoveFromCart(int productId);
        
        // Increase and decrease quantity of product in cart
        Task<Response<bool>> IncreaseQuantity(int productId);
        Task<Response<bool>> DecreaseQuantity(int productId);
        
        // Apply promo code
        Task<Response<bool>> PromoCode(string code);
    }
}