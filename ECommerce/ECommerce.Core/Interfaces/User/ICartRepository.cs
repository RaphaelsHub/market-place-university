using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.Core.Entities.User;
using ECommerce.Core.Models.DTOs.Cart;

namespace ECommerce.Core.Interfaces.User
{
    public interface ICartRepository
    {
        Task<List<CartItemEf>> GetCartByUserIdAsync(int userId);
        Task<CartItemEf> AddToCartAsync(int userId, CartItemEf cartItem);
        Task<CartItemEf> UpdateCartAsync(int userId, CartItemEf cartItem);
        Task<bool> RemoveFromCartAsync(int userId, int productId);
    }
}