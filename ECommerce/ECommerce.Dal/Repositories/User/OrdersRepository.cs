using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using ECommerce.Core.Entities.User;
using ECommerce.Core.Interfaces.User;

namespace ECommerce.Dal.Repositories.User
{
    public class OrdersRepository : IOrdersRepository<OrderEf>
    {
        private readonly StoreContext _context;
        
        public OrdersRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrderEf>> GetAllAsync() =>
            await _context.Orders.ToListAsync();

        public async Task<OrderEf> GetByIdAsync(int id) =>
            await _context.Orders.FirstOrDefaultAsync(x => x.OrderId == id);

        public async Task CreateAsync(OrderEf entity)
        {
            _context.Orders.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(OrderEf entity)
        {
            _context.Orders.Attach(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.OrderId == id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }
    }
}