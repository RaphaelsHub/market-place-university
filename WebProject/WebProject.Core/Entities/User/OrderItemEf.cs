using WebProject.Core.Entities.Product;

namespace WebProject.Core.Entities.User
{
    public class OrderItemEf
    {
        public uint OrderItemId { get; set; }
        
        public uint Quantity { get; set; }
        
        public uint ProductId { get; set; }
        public ProductEf Product { get; set; }
        
        public uint OrderId { get; set; }
        public OrderEf Order { get; set; }
        
        public uint UserId { get; set; }
        public UserEf User { get; set; }
    }
}