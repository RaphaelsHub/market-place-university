using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Build.Framework.XamlTypes;
using WebProject.Core.DTO;
using WebProject.Core.Enums;

namespace WebProject.Core.Entities
{
    public class ProductEf
    {
        [Key]
        [Column("ProductId")]
        public int ProductId { get; set; }
        
        [Required(ErrorMessage = "Please enter the product name")]
        [StringLength(31, MinimumLength = 4, ErrorMessage = "The name must be between 4 and 31 characters")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Please enter the start amount")]
        [Range(int.MinValue, int.MaxValue, ErrorMessage = "Please enter an integer number")]
        public int StartAmount { get; set; }
        
        [Required(ErrorMessage = "Please enter the current amount")]
        [Range(int.MinValue, int.MaxValue, ErrorMessage = "Please enter an integer number")]
        public int CurrentAmount { get; set; }
        
        [Required(ErrorMessage = "Please enter the short description")]
        [StringLength(127, MinimumLength = 32, ErrorMessage = "The short description must be between 32 and 127 characters")]
        public string ShortDescription { get; set; }
        
        [Required(ErrorMessage = "Please enter the full description")]
        [StringLength(512, MinimumLength = 127, ErrorMessage = "The full description must be between 127 and 512 characters")]
        public string FullDescription { get; set; }
        
        [Required(ErrorMessage = "Please enter the start price")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive number")]
        public decimal Price { get; set; }
        
        public float PercentageDiscount { get; set; } = 0;
        
        public DateTime DatePost { get; set; } = DateTime.Now;
        public ProductSellType ProductSellType { get; set; } = ProductSellType.IsVisible;
        public ProductStatus ProductStatus { get; set; } = ProductStatus.InStock;

        public byte[][] Image { get; set; }

        public Category Category { get; set; }
        public RattingEf Ratting { get; set; }
    }
}