using ECommerce.Core.Entities.Product;

namespace ECommerce.Core.Entities.User
{
    public class CartItemEf
    {
        
        public uint Quantity { get; set; }
        
        // Foreign key for the product.
        public int ProductId { get; set; }
        public ProductEf Product { get; set; }
        
        // Foreign key for the user.
        public int UserId { get; set; }
        public UserEf User { get; set; }
    }
}