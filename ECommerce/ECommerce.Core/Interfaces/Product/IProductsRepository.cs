using ECommerce.Core.Entities.Product;

namespace ECommerce.Core.Interfaces.Product
{
    public interface IProductsRepository<T> : IGenericRepository<ProductEf>
    {
        
    }
}