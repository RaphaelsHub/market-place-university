using System.Threading.Tasks;
using WebProject.Core.DTO;
using WebProject.Core.DTO.ResponcesDto;

namespace WebProject.App.Interfaces
{
    public interface IProductService
    {
        // CRUD Operations
        Task<Response<ProductDto>> CreateProductAsync(ProductDto product);
        Task<Response<ProductDto>> GetProductByIdAsync(uint id);
        Task<Response<ProductDto>> UpdateProductAsync(ProductDto product);
        Task<Response<ProductDto>> DeleteProductAsync(uint id);        
        
        // Other Operations, Get all products, by assigning currentPage and amountOfItemsPerPage
        Task<Response<ProductDto>> GetProductsAsync(uint currentPage, uint amountOfItemsPerPage); 
        Task<Response<ProductDto>> GetProductsByNameAsync(string name, uint currentPage, uint amountOfItems); 
        Task<Response<ProductDto>> GetProductsByCategoryAsync(string category, uint currentPage, uint amountOfItems);
    }
}