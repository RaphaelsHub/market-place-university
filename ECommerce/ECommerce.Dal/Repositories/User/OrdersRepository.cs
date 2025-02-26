using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Core.Entities.User;
using ECommerce.Core.Enums.Order;
using ECommerce.Core.Interfaces.User;
using ExpressMapper;

namespace ECommerce.Dal.Repositories.User
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly StoreContext _context;
        
        public OrdersRepository(StoreContext context)
            => _context = context;


        public async Task<OrderEf> GetByIdAsync(int id)
        {
            var orderEf = await _context.Orders.FirstOrDefaultAsync(x => x.OrderId == id);
            await _context.SaveChangesAsync();
            return orderEf;
        }

        public async Task<OrderEf> CreateAsync(OrderEf entity)
        {
            _context.Orders.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<OrderEf> UpdateAsync(OrderEf entity)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.OrderId == entity.OrderId);
            if(order!=null)
            {
                Mapper.Map<OrderEf, OrderEf>(entity, order);
                await _context.SaveChangesAsync();
                return order;
            }
            return null;
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

        public async Task<List<OrderEf>> GetOrdersAsync(int? userId, OrderStatus orderStatus, int currentPage, int amountOfItemsPerPage)
        {
            var query = _context.Orders.AsQueryable();

            if (userId.HasValue)
            {
                query = query.Where(x => x.UserId == userId);
            }

            query = query.Where(x => x.Status == orderStatus);

            return await query.Skip((currentPage - 1) * amountOfItemsPerPage).Take(amountOfItemsPerPage).ToListAsync();
        }

    }
}