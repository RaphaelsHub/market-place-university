using ECommerce.Core.Entities.Product;

namespace ECommerce.Core.Entities.User
{
    public class OrderItemEf
    {
        public int OrderItemId { get; set; }
        
        public uint Quantity { get; set; }
        
        public int ProductId { get; set; }
        public ProductEf Product { get; set; }
        
        public int OrderId { get; set; }
        public OrderEf Order { get; set; }
        
        public int UserId { get; set; }
        public UserEf User { get; set; }
    }
}