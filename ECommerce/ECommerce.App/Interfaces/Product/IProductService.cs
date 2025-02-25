using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.Core.Models.DTOs.GenericResponses;
using ECommerce.Core.Models.DTOs.Product;

namespace ECommerce.App.Interfaces.Product
{
    public interface IProductService
    {
        Task<BaseResponse<ProductDto>> CreateProductAsync(ProductDto product);
        Task<BaseResponse<ProductDto>> GetProductByIdAsync(int id);
        Task<BaseResponse<List<ProductDto>>> GetProductsAsync(string productName, int categoryId, int page, int pageSize);
        Task<BaseResponse<List<ProductDto>>> GetProductsByMostViewedAsync(int amount);
        Task<BaseResponse<ProductDto>> UpdateProductAsync(ProductDto product);
        Task<BaseResponse<bool>> DeleteProductByIdAsync(int id);    
    }
}