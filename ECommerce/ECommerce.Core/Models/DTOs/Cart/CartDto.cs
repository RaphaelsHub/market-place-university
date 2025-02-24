using System.Linq;
using System.Collections.Generic;

namespace ECommerce.Core.Models.DTOs.Cart
{
    public class CartDto
    {
        public List<CartItemDto> Products { get; set; }
        public decimal SubTotalPrice => Products.Sum(x => x.Product.Price * x.Quantity);
        public decimal Save => Products.Sum(x => x.Product.Price * x.Quantity * (decimal)x.Product.PercentageDiscount);
        public decimal FinalPrice => SubTotalPrice - Save;
        
        public CartDto(List<CartItemDto> products)
        {
            Products = products;
        }
    }
}