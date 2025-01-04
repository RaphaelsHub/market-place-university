using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebProject.Core.Enums;

namespace WebProject.Core.Entities
{
    public class ProductEf
    {
        /// <summary>
        /// Gets or sets the unique identifier for the product.
        /// </summary>
        [Key]
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        [Required]
        [MaxLength(31)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the initial quantity of the product.
        /// </summary>
        [Required]
        [Range(int.MinValue, int.MaxValue)]
        public int StartAmount { get; set; }

        /// <summary>
        /// Gets or sets the current quantity of the product.
        /// </summary>
        [Required]
        [Range(int.MinValue, int.MaxValue)]
        public int CurrentAmount { get; set; }

        /// <summary>
        /// Gets or sets a short description of the product.
        /// </summary>
        [Required]
        [StringLength(127, MinimumLength = 32)]
        public string ShortDescription { get; set; }

        /// <summary>
        /// Gets or sets a full description of the product.
        /// </summary>
        [Required]
        [StringLength(512, MinimumLength = 127)]
        public string FullDescription { get; set; }

        /// <summary>
        /// Gets or sets the price of the product.
        /// </summary>
        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the discount percentage applied to the product.
        /// </summary>
        public float PercentageDiscount { get; set; } = 0;

        /// <summary>
        /// Gets or sets the date when the product was posted.
        /// </summary>
        public DateTime DatePost { get; set; } = DateTime.Now;

        /// <summary>
        /// Gets or sets the visibility type of the product.
        /// </summary>
        public ProductSellType ProductSellType { get; set; } = ProductSellType.IsVisible;

        /// <summary>
        /// Gets the stock status of the product based on the current amount.
        /// </summary>
        [NotMapped]
        public ProductStatus ProductStatus => CurrentAmount > 0 ? ProductStatus.InStock : ProductStatus.OutOfStock;

        /// <summary>
        /// Gets or sets the images associated with the product.
        /// </summary>
        public byte[][] Image { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the category associated with the product.
        /// </summary>
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public CategoryEf Category { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the rating associated with the product.
        /// </summary>
        public uint RatingId { get; set; }
        [ForeignKey("RatingId")]
        public RatingEf Ratting { get; set; }
        
        [InverseProperty("Product")]
        public List<RateItemEf> RateItems { get; set; } = new List<RateItemEf>();
    }
}
