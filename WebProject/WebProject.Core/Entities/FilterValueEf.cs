using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProject.Core.Entities
{
    public class FilterValueEf
    {
        /// <summary>
        ///   Unique identifier of the filter value.
        /// </summary>
        [Key]
        public uint FilterValueId { get; set; }
        
        /// <summary>
        ///  Name of the filter value.
        /// </summary>
        [Required]
        [MaxLength(31)]
        public string FilterValueName { get; set; }
        
        /// <summary>
        ///  Availability of the filter value.
        /// </summary>
        public bool IsAvailable { get; set; } = false;
        
        /// <summary>
        ///  Unique identifier of the filter.
        /// </summary>
        [Required]
        [Range(0, uint.MaxValue)]
        public uint FilterId { get; set; }
        [ForeignKey("FilterId")]
        public FilterEf Filter { get; set; }
    }
}