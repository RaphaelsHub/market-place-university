using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.App.Interfaces.Product;
using ECommerce.Core.Entities.Product;
using ECommerce.Core.Interfaces.Product;
using ECommerce.Core.Models.DTOs.GenericResponses;
using ECommerce.Core.Models.DTOs.Product;
using ExpressMapper;
using OperationStatus = ECommerce.Core.Enums.Request.OperationStatus;

namespace ECommerce.App.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly IProductsRepository _productsRepository;
        
        public ProductService(IProductsRepository productsRepository) =>
            _productsRepository = productsRepository;

        public async Task<BaseResponse<ProductDto>> CreateProductAsync(ProductDto product)
        {
            var productEf = Mapper.Map<ProductDto, ProductEf>(product);

            var returnedProductEf = await _productsRepository.CreateAsync(productEf);
            
            var returnedProductDto = Mapper.Map<ProductEf, ProductDto>(returnedProductEf);
            
            return returnedProductEf == null ? 
                new BaseResponse<ProductDto>(null, OperationStatus.Error, "Product not created") : 
                new BaseResponse<ProductDto>(returnedProductDto, OperationStatus.Success, "Product created");
        }

        public async Task<BaseResponse<ProductDto>> GetProductByIdAsync(int id)
        {
            var productEf = await _productsRepository.GetByIdAsync(id); 
            
            if (productEf == null)
                return new BaseResponse<ProductDto>(null, OperationStatus.Success, "Product not found");
            return new BaseResponse<ProductDto>(Mapper.Map<ProductEf, ProductDto>(productEf), OperationStatus.Success, "ok");
        }

        public async Task<BaseResponse<List<ProductDto>>> GetProductsAsync(string productName, int categoryId, int page, int pageSize)
        {
            var list = (await _productsRepository.GetPaginatedProductsByNameAndCategoryAsync(productName,categoryId, page, pageSize)).ToList();
            return new BaseResponse<List<ProductDto>>( list.Select(Mapper.Map<ProductEf, ProductDto>).ToList(), OperationStatus.Success, "ok");
        }

        public async Task<BaseResponse<List<ProductDto>>> GetProductsByMostViewedAsync(int amount)
        {
            var list = (await _productsRepository.GetProductsByMostViewedAsync(amount)).ToList();
            return new BaseResponse<List<ProductDto>>( list.Select(Mapper.Map<ProductEf, ProductDto>).ToList(), OperationStatus.Success, "ok");
        }


        public async Task<BaseResponse<ProductDto>> UpdateProductAsync(ProductDto product)
        {
            var productEf = Mapper.Map<ProductDto, ProductEf>(product);
            
            var returnedProductEf = await _productsRepository.UpdateAsync(productEf);
            
            if (returnedProductEf == null)
                return new BaseResponse<ProductDto>(null, OperationStatus.Error, "Product not updated");
            return new BaseResponse<ProductDto>(Mapper.Map<ProductEf, ProductDto>(returnedProductEf), OperationStatus.Success, "Product updated");
        }

        public async Task<BaseResponse<bool>> DeleteProductByIdAsync(int id)
        {
            await _productsRepository.DeleteByIdAsync(id);
            return new BaseResponse<bool>(true, OperationStatus.Success, "Product deleted");
        }
    }
}