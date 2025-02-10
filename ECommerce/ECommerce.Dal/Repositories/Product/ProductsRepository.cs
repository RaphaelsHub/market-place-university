using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.Core.Entities.Product;
using ECommerce.Core.Interfaces.Product;

namespace ECommerce.Dal.Repositories.Product
{
    public class ProductsRepository : IProductsRepository<ProductEf>
    {
        private readonly StoreContext _context;

        public ProductsRepository(StoreContext context)
        {
            _context = context;
        }
        
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