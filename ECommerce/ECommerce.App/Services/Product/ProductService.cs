using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerce.App.Interfaces.Product;
using ECommerce.Core.Entities.Product;
using ECommerce.Core.Interfaces.Product;
using ECommerce.Core.Models;
using ECommerce.Core.Models.DTOs.Product;
using ECommerce.Core.Models.ViewModels;

namespace ECommerce.App.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly IProductsRepository<ProductEf> _productsRepository;
        
        public ProductService(IProductsRepository<ProductEf> productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public Task<ResponseViewModel<bool>> CreateProductAsync(ProductDto product)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseViewModel<ProductDto>> GetProductAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseViewModel<IEnumerable<ProductDto>>> GetProductsAsync(int categoryId, int currentPage = 1, int amountOfItemsPerPage = 16)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseViewModel<IEnumerable<ProductDto>>> GetProductsAsync(string search, int categoryId = 0, int currentPage = 1, int amountOfItemsPerPage = 16)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseViewModel<bool>> UpdateProductAsync(ProductDto product)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseViewModel<bool>> DeleteProductAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}