using System.Threading.Tasks;
using WebProject.App.Interfaces;
using WebProject.Core.DTO;
using WebProject.Core.DTO.FeedBack.Standard;

namespace WebProject.App.Services
{
    public class ProductService : IProductService
    {
        public Task<Response<ProductDto>> CreateProductAsync(ProductDto product)
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<ProductDto>> GetProductByIdAsync(uint id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<ProductDto>> UpdateProductAsync(ProductDto product)
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<ProductDto>> DeleteProductAsync(uint id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<ProductDto>> GetProductsAsync(uint currentPage, uint amountOfItemsPerPage)
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<ProductDto>> GetProductsByNameAsync(string name, uint currentPage, uint amountOfItems)
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<ProductDto>> GetProductsByCategoryAsync(string category, uint currentPage, uint amountOfItems)
        {
            throw new System.NotImplementedException();
        }
    }
}