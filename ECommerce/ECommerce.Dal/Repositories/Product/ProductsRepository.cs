using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Core.Entities.Product;
using ECommerce.Core.Interfaces.Product;
using ExpressMapper;

namespace ECommerce.Dal.Repositories.Product
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly StoreContext _context;

        public ProductsRepository(StoreContext context) 
            => _context = context;

        public async Task<ProductEf> CreateAsync(ProductEf entity)
        {
            _context.Products.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        
        public async Task<ProductEf> GetByIdAsync(int id) =>
            await _context.Products.FindAsync(id);
        
        public async Task<IEnumerable<ProductEf>> GetPaginatedProductsByNameAndCategoryAsync(string productName,
            int categoryId, int page, int pageSize)
        {
            var request = _context.Products.AsQueryable();
            if (!string.IsNullOrEmpty(productName)) request = request.Where(x => x.ProductName.Contains(productName));
            if (categoryId > 0) request = request.Where(x=>x.CategoryId == categoryId);
            
            return await request.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<IEnumerable<ProductEf>> GetProductsByMostViewedAsync(int amount)
        {
            return await _context.Products.OrderByDescending(x => x.Views).Take(amount).ToListAsync();
        }

        public async Task<ProductEf> UpdateAsync(ProductEf entity)
        {
            var existingProduct = await _context.Products.FindAsync(entity.ProductId);
            if (existingProduct == null) return null;
            
            Mapper.Map(entity, existingProduct);

            await _context.SaveChangesAsync();
            return existingProduct;
        }
        
        public async Task DeleteByIdAsync(int id)
        {
            var product = await _context.Products.SingleOrDefaultAsync(x => x.ProductId == id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}