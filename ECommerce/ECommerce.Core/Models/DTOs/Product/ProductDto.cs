using ECommerce.Core.Enums.Entity;

namespace ECommerce.Core.Models.DTOs.Product
{
    public class ProductDto
    {
        public int ProductId { get; set; } = 0;
        public string Name { get; set; }    
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public decimal Price { get; set; }
        public float PercentageDiscount { get; set; }
        public decimal PriceWithDiscount => Price - Price * (decimal)PercentageDiscount / 100;
        public int StartAmount { get; set; }
        public int CurrentAmount { get; set; }
        public int Views { get; set; } = 0;
        public EntityStatus EntityStatus { get; set; }
        public byte[] Image { get; set; }
        
        public int CategoryId { get; set; }
    }
}