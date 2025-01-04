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
        [Required]
        [Range(0, uint.MaxValue)]
        public uint ProductId { get; set; }
        [ForeignKey("ProductId")]
        public ProductEf Product { get; set; }
    }
}