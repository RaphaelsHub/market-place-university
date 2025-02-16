using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.Core.Models;
using ECommerce.Core.Models.DTOs.Product;
using ECommerce.Core.Models.ViewModels;

namespace ECommerce.App.Interfaces.Product
{
    /// <summary>
    /// Product service, which allows to create, read, update, delete product, find product by search, find product by category
    /// </summary>
    public interface IProductService
    {
        Task<ResponseViewModel<bool>> CreateProductAsync(ProductDto product);
        Task<ResponseViewModel<ProductDto>> GetProductAsync(int id);
        Task<ResponseViewModel<IEnumerable<ProductDto>>> GetProductsAsync(int categoryId, int currentPage = 1, int amountOfItemsPerPage = 16); 
        Task<ResponseViewModel<IEnumerable<ProductDto>>> GetProductsAsync(string search, int categoryId = 0, int currentPage = 1, int amountOfItemsPerPage = 16);
        Task<ResponseViewModel<bool>> UpdateProductAsync(ProductDto product);
        Task<ResponseViewModel<bool>> DeleteProductAsync(int id);    
    }
}