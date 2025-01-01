using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProject.Core.Entities
{
    public class RatingEf
    {
        /// <summary>
        /// The unique identifier for the rating.
        /// </summary>
        [Key]
        public uint RatingId { get; set; }

        /// <summary>
        /// The number of likes.
        /// </summary>
        public uint Likes { get; set; }

        /// <summary>
        /// The number of dislikes.
        /// </summary>
        public uint Dislikes { get; set; }

        /// <summary>
        /// The number of views.
        /// </summary>
        public uint Views { get; set; }

        /// <summary>
        /// The product identifier.
        /// </summary>
        public uint ProductId { get; set; }

        /// <summary>
        /// The associated product.
        /// </summary>
        [ForeignKey("ProductId")]
        public ProductEf Product { get; set; }
    }
}