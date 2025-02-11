using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using ECommerce.Core.Entities.User;
using ECommerce.Core.Interfaces.User;

namespace ECommerce.Dal.Repositories.User
{
    public class CartItemsRepository : ICartItemsRepository<CartItemEf>
    {
        private readonly StoreContext _context;

        public CartItemsRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CartItemEf>> GetAllAsync() =>
            await _context.CartItems.ToListAsync();

        public async Task<CartItemEf> GetByIdAsync(int id) =>
            await _context.CartItems.FirstOrDefaultAsync(x => x.ProductId == id);

        public async Task CreateAsync(CartItemEf entity)
        {
            _context.CartItems.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CartItemEf entity)
        {
            _context.CartItems.Attach(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var cartItem = await _context.CartItems.FirstOrDefaultAsync(x => x.ProductId == id);
            if (cartItem != null)
            {
                _context.CartItems.Remove(cartItem);
                await _context.SaveChangesAsync();
            }
        }
    }
}