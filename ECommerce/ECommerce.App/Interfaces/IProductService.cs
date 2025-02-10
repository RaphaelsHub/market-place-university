using System.Threading.Tasks;
using ECommerce.Core.DataTransferObjects;
using ECommerce.Core.DataTransferObjects.FeedBack.Standard;

namespace ECommerce.App.Interfaces
{
    public interface IProductService
    {
        // CRUD Operations
        Task<ResponseType1<ProductDto>> CreateProductAsync(ProductDto product);
        Task<ResponseType1<ProductDto>> GetProductByIdAsync(uint id);
        Task<ResponseType1<ProductDto>> UpdateProductAsync(ProductDto product);
        Task<ResponseType1<ProductDto>> DeleteProductAsync(uint id);        
        
        // Other Operations, Get all products, by assigning currentPage and amountOfItemsPerPage
        Task<ResponseType1<ProductDto>> GetProductsAsync(uint currentPage, uint amountOfItemsPerPage); 
        Task<ResponseType1<ProductDto>> GetProductsByNameAsync(string name, uint currentPage, uint amountOfItems); 
        Task<ResponseType1<ProductDto>> GetProductsByCategoryAsync(string category, uint currentPage, uint amountOfItems);
    }
}