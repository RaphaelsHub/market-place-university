using System.Collections.Generic;
using System.Threading.Tasks;
using WebProject.Core.Entities.User;
using WebProject.Core.Interfaces.User;

namespace WebProject.Dal.Repositories.User
{
    public class CartItemsRepository : ICartItemsRepository<CartItemEf>
    {
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