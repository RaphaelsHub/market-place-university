using System.Threading.Tasks;
using WebProject.App.Interfaces;
using WebProject.Core.DTO;
using WebProject.Core.DTO.FeedBack.Standard;

namespace WebProject.App.Services
{
    public class ProductService : IProductService
    {
        public Task<ResponseType1<ProductDto>> CreateProductAsync(ProductDto product)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseType1<ProductDto>> GetProductByIdAsync(uint id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseType1<ProductDto>> UpdateProductAsync(ProductDto product)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseType1<ProductDto>> DeleteProductAsync(uint id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseType1<ProductDto>> GetProductsAsync(uint currentPage, uint amountOfItemsPerPage)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseType1<ProductDto>> GetProductsByNameAsync(string name, uint currentPage, uint amountOfItems)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseType1<ProductDto>> GetProductsByCategoryAsync(string category, uint currentPage, uint amountOfItems)
        {
            throw new System.NotImplementedException();
        }
    }
}