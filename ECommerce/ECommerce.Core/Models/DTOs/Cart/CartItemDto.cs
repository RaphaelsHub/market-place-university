using ECommerce.Core.Models.DTOs.Product;

namespace ECommerce.Core.Models.DTOs.Cart
{
    public class CartItemDto
    {
        public ProductDto Product { get; set; }
        public int Quantity { get; set; }
    }
}