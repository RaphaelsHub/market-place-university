using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using ECommerce.Core.Entities.User;
using ECommerce.Core.Interfaces.User;

namespace ECommerce.Dal.Repositories.User
{
    public class OrderItemsRepository : IOrderItemsRepository<OrderItemEf>
    {
        private readonly StoreContext _context;

        public OrderItemsRepository(StoreContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<OrderItemEf>> GetAllAsync() =>
            await _context.OrderItems.ToListAsync();

        public async Task<OrderItemEf> GetByIdAsync(int id) =>
            await _context.OrderItems.FirstOrDefaultAsync(x => x.OrderItemId == id);

        public async Task CreateAsync(OrderItemEf entity)
        {
            _context.OrderItems.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(OrderItemEf entity)
        {
            _context.OrderItems.Attach(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var orderItem = await _context.OrderItems.FirstOrDefaultAsync(x => x.OrderItemId == id);
            if (orderItem != null)
            {
                _context.OrderItems.Remove(orderItem);
                await _context.SaveChangesAsync();
            }
        }
    }
}