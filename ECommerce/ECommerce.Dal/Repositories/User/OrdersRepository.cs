using System.Collections.Generic;
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
        
        public Task<IEnumerable<OrderEf>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<OrderEf> GetByIdAsync(uint id)
        {
            throw new System.NotImplementedException();
        }

        public Task AddAsync(OrderEf entity)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(OrderEf entity)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteByIdAsync(uint id)
        {
            throw new System.NotImplementedException();
        }
    }
}