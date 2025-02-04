using System.Collections.Generic;
using System.Threading.Tasks;
using WebProject.Core.Entities.Product;
using WebProject.Core.Interfaces.Product;

namespace WebProject.Dal.Repositories.Product
{
    public class RateItemsRepository : IRateItemsRepository<RateItemEf>
    {
        public Task<IEnumerable<RateItemEf>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<RateItemEf> GetByIdAsync(uint id)
        {
            throw new System.NotImplementedException();
        }

        public Task AddAsync(RateItemEf entity)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(RateItemEf entity)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteByIdAsync(uint id)
        {
            throw new System.NotImplementedException();
        }
    }
}