using System.Collections.Generic;
using System.Threading.Tasks;
using WebProject.Core.Entities.User;
using WebProject.Core.Interfaces.User;

namespace WebProject.Dal.Repositories.User
{
    public class OrderItemsRepository : IOrderItemsRepository<OrderItemEf>
    {
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