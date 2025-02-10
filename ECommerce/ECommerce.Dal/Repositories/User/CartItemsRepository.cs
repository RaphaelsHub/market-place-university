using System.Collections.Generic;
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
        public Task<IEnumerable<CartItemEf>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<CartItemEf> GetByIdAsync(uint id)
        {
            throw new System.NotImplementedException();
        }

        public Task AddAsync(CartItemEf entity)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(CartItemEf entity)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteByIdAsync(uint id)
        {
            throw new System.NotImplementedException();
        }
    }
}