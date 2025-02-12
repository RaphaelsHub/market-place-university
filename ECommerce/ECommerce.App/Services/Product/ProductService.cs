using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.App.Interfaces.Product;
using ECommerce.Core.DataTransferObjects;
using ECommerce.Core.DataTransferObjects.Responses;
using ECommerce.Core.Entities.Product;
using ECommerce.Core.Interfaces.Product;

namespace ECommerce.App.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly IProductsRepository<ProductEf> _productsRepository;
        
        public ProductService(IProductsRepository<ProductEf> productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public Task<ResponseType1<bool>> CreateProductAsync(ProductDto product)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseType1<ProductDto>> GetProductAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseType1<IEnumerable<ProductDto>>> GetProductsAsync(int categoryId, int currentPage = 1, int amountOfItemsPerPage = 16)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseType1<IEnumerable<ProductDto>>> GetProductsAsync(string search, int categoryId = 0, int currentPage = 1, int amountOfItemsPerPage = 16)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseType1<bool>> UpdateProductAsync(ProductDto product)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseType1<bool>> DeleteProductAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}