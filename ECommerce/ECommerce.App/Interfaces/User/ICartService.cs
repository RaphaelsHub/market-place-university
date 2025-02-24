using System.Threading.Tasks;
using ECommerce.Core.Models.DTOs.Cart;
using ECommerce.Core.Models.DTOs.GenericResponses;

namespace ECommerce.App.Interfaces.User
{
    public interface ICartService 
    {
        Task<BaseResponse<CartDto>> GetCart(); 
        
        Task<BaseResponse<bool>> AddToCartByProductId(int productId); 
        Task<BaseResponse<bool>> RemoveFromCart(int productId);
        
        Task<BaseResponse<bool>> IncreaseQuantity(int productId);
        Task<BaseResponse<bool>> DecreaseQuantity(int productId);
    }
}