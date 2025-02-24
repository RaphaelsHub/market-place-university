using ECommerce.Core.Entities.Product;

namespace ECommerce.Core.Entities.User
{
    public class CartItemEf
    {
        public int Quantity { get; set; }
        
        public int ProductId { get; set; }
        public ProductEf Product { get; set; }
        
        public int UserId { get; set; }
        public UserEf User { get; set; }
    }
}