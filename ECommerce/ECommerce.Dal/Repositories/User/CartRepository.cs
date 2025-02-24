using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using ECommerce.Core.Entities.User;
using ECommerce.Core.Interfaces.User;

namespace ECommerce.Dal.Repositories.User
{
    public class CartRepository : ICartRepository
    {
        private readonly StoreContext _context;

        public CartRepository(StoreContext context) =>
            _context = context;

        private async Task<UserEf> GetUserWithCartAsync(int userId)
        {
            return await _context.Users.Include(x => x.Cart).FirstOrDefaultAsync(x => x.UserId == userId);
        }

        public async Task<List<CartItemEf>> GetCartByUserIdAsync(int userId)
        {
            var user = await GetUserWithCartAsync(userId);
            return user?.Cart;
        }

        public async Task<CartItemEf> AddToCartAsync(int userId, CartItemEf cartItem)
        {
            var user = await GetUserWithCartAsync(userId);
            if (user == null)
                return null;

            if (user.Cart == null)
            {
                user.Cart = new List<CartItemEf> { cartItem };
            }
            else
            {
                var existingItem = user.Cart.Find(item => item.ProductId == cartItem.ProductId);
                if (existingItem != null)
                {
                    existingItem.Quantity += cartItem.Quantity;
                    return existingItem;
                }

                user.Cart.Add(cartItem);
            }

            return cartItem;
        }

        public async Task<CartItemEf> UpdateCartAsync(int userId, CartItemEf cartItem)
        {
            var user = await GetUserWithCartAsync(userId);
            if (user == null || user.Cart == null)
                return null;

            var existingItem = user.Cart.Find(item => item.ProductId == cartItem.ProductId);
            if (existingItem != null)
            {
                existingItem.Quantity += cartItem.Quantity;
                return existingItem;
            }

            return null;
        }

        public async Task<bool> RemoveFromCartAsync(int userId, int productId)
        {
            var user = await GetUserWithCartAsync(userId);
            if (user?.Cart == null) return false;

            var item = user.Cart.Find(cartItem => cartItem.ProductId == productId);
            if (item != null)
            {
                user.Cart.Remove(item);
                return true;
            }

            return false;
        }
    }
}
