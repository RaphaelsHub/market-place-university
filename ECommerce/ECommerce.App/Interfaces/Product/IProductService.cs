using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.Core.DataTransferObjects;
using ECommerce.Core.DataTransferObjects.FeedBack.Standard;

namespace ECommerce.App.Interfaces.Product
{
    /// <summary>
    /// Product service, which allows to create, read, update, delete product, find product by search, find product by category
    /// </summary>
    public interface IProductService
    {
        Task<ResponseType1<bool>> CreateProductAsync(ProductDto product);
        Task<ResponseType1<ProductDto>> GetProductAsync(int id);
        Task<ResponseType1<IEnumerable<ProductDto>>> GetProductsAsync(int categoryId, int currentPage = 1, int amountOfItemsPerPage = 16); 
        Task<ResponseType1<IEnumerable<ProductDto>>> GetProductsAsync(string search, int categoryId = 0, int currentPage = 1, int amountOfItemsPerPage = 16);
        Task<ResponseType1<bool>> UpdateProductAsync(ProductDto product);
        Task<ResponseType1<bool>> DeleteProductAsync(int id);    
    }
}