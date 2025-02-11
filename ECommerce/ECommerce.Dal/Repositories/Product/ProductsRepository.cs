using System.Collections.Generic;
using System.Data.Entity;
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

        public async Task<IEnumerable<ProductEf>> GetAllAsync() =>
            await _context.Products.ToListAsync();

        public async Task<ProductEf> GetByIdAsync(int id) =>
            await _context.Products.FirstOrDefaultAsync(x => x.ProductId == id);

        public async Task CreateAsync(ProductEf entity)
        {
            _context.Products.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProductEf entity)
        {
            _context.Products.Attach(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}