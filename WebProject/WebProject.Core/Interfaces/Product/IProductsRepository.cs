using WebProject.Core.Entities.Product;

namespace WebProject.Core.Interfaces.Product
{
    public interface IProductsRepository<T> : IGenericRepository<ProductEf>
    {
        
    }
}