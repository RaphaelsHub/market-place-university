using System.Collections.Generic;
using System.Threading.Tasks;
using WebProject.Core.Entities.Product;
using WebProject.Core.Interfaces.Product;

namespace WebProject.Dal.Repositories.Product
{
    public class ProductsRepository : IProductsRepository<ProductEf>
    {
        public Task<IEnumerable<ProductEf>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<ProductEf> GetByIdAsync(uint id)
        {
            throw new System.NotImplementedException();
        }

        public Task AddAsync(ProductEf entity)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(ProductEf entity)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteByIdAsync(uint id)
        {
            throw new System.NotImplementedException();
        }
    }
}