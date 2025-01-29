using System;
using System.Collections.Generic;
using WebProject.Core.Entities.Product;
using WebProject.Core.Enums.Product;

namespace WebProject.Core.DTO
{
    public class ProductDto
    {
        public uint ProductId { get; set; }
        public uint StartAmount { get; set; }
        public uint CurrentAmount { get; set; }
        public uint Views { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        private float PercentageDiscount { get; set; } = 0;
        private decimal Price { get; set; } = 0;
        public decimal PriceWithDiscount => Price - Price * (decimal)PercentageDiscount / 100;
        public DateTime DatePost { get; set; } 
        public ProductSellType ProductSellType { get; set; }
        public ProductStockStatus ProductStatus { get; set; }

        public ProductVisibilityStatus ProductVisibilityStatus { get; set; }
        public byte[][] Image { get; set; }

        public uint CategoryId { get; set; }
        public CategoryEf Category { get; set; }
        
        public List<RateItemEf> RateItems { get; set; } = new List<RateItemEf>();
    }
}