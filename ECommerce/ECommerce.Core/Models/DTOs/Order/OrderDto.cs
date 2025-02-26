namespace ECommerce.Core.Models.DTOs.Order
{
    public class OrderDto
    {
        public OrderDataDto OrderData { get; set; }
        public OrderStatusDto OrderStatus { get; set; }
        public PaymentDto Payment { get; set; }
    }
}