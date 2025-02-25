using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.Core.Entities.Product;

namespace ECommerce.Core.Interfaces.Product
{
    public interface IProductsRepository : IGenericRepository<ProductEf>
    {
        Task<IEnumerable<ProductEf>> GetPaginatedProductsByNameAndCategoryAsync(string productName, int categoryId, int page, int pageSize);
        Task<IEnumerable<ProductEf>> GetProductsByMostViewedAsync(int amount);
    }
}