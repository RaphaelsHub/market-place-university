using System.Collections.Generic;
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
        
        public Task<IEnumerable<OrderItemEf>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<OrderItemEf> GetByIdAsync(uint id)
        {
            throw new System.NotImplementedException();
        }

        public Task AddAsync(OrderItemEf entity)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(OrderItemEf entity)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteByIdAsync(uint id)
        {
            throw new System.NotImplementedException();
        }
    }
}