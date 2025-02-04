using System.Collections.Generic;
using System.Threading.Tasks;
using WebProject.Core.Entities.User;
using WebProject.Core.Interfaces.User;

namespace WebProject.Dal.Repositories.User
{
    public class OrdersRepository : IOrdersRepository<OrderEf>
    {
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