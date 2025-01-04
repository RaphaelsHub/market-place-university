using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProject.Core.Entities
{
    public class FilterEf
    {
        /// <summary>
        ///  Unique identifier of the filter.
        /// </summary>
        [Key]
        public uint FilterId { get; set; }
        
        /// <summary>
        ///  Name of the filter.
        /// </summary>
        [Required]
        [MaxLength(31)]
        public string FilterName { get; set; }
        
        /// <summary>
        ///  Values of the filter.
        /// </summary>
        [InverseProperty("Filter")]
        public List<FilterValueEf> FilterValues { get; set; } = new List<FilterValueEf>();

        /// <summary>
        /// Unique identifier of the category.
        /// </summary>
        [Required]
        [Range(0, uint.MaxValue)]
        public uint CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public CategoryEf Category { get; set; }
    }
}