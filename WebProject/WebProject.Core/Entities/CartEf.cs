using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProject.Core.Entities
{
    public class CartEf
    {
        /// <summary>
        ///  The quantity of the product.
        /// </summary>
        [Required]
        [Range(1, uint.MaxValue)]
        public uint Quantity { get; set; }
        
        /// <summary>
        /// The product identifier.
        /// </summary>
        [Required]
        [Range(0, uint.MaxValue)]
        public uint ProductId { get; set; }
        [ForeignKey("ProductId")]
        public ProductEf Product { get; set; }
        
        /// <summary>
        ///  The user identifier.
        /// </summary>
        [Required]
        [Range(0, uint.MaxValue)]
        public uint UserId { get; set; }
        [ForeignKey("UserId")]
        public UserEf User { get; set; }
    }
}