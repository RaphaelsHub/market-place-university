using ECommerce.Core.Enums.Order;

namespace ECommerce.Core.Models.DTOs.Order
{
    public class PaymentDto
    {
        public decimal SubTotalPrice { get; set; }
        
        public decimal TotalPrice { get; set; }
        
        public decimal DiscountPrice { get; set; }
        
        public PaymentType PaymentType { get; set; }
    }
}