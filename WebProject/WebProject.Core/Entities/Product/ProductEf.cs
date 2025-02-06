using System;
using System.Collections.Generic;
using WebProject.Core.Enums.Product;

namespace WebProject.Core.Entities.Product
{
    public class ProductEf
    {
        public int ProductId { get; set; }
        public uint StartAmount { get; set; }
        public uint CurrentAmount { get; set; }
        public uint Views { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        private float PercentageDiscount { get; set; } = 0;
        private decimal Price { get; set; } = 0;
        public decimal PriceWithDiscount => Price - Price * (decimal)PercentageDiscount / 100;
        public DateTime DatePost { get; set; } = DateTime.Now;
        public ProductSellType ProductSellType { get; set; } = ProductSellType.Normal;
        public ProductStockStatus ProductStatus => CurrentAmount > 0 ?  
            ProductStockStatus.InStock :  
            ProductStockStatus.OutOfStock;

        public ProductVisibilityStatus ProductVisibilityStatus { get; set; } = ProductVisibilityStatus.IsHidden;
        public byte[][] Image { get; set; }

        public int CategoryId { get; set; }
        public CategoryEf Category { get; set; }
        
        public List<RateItemEf> RateItems { get; set; } = new List<RateItemEf>();
    }
}
