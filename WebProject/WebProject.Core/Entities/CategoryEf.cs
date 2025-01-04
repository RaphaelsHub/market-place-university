using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProject.Core.Entities
{
    public class CategoryEf
    {
        /// <summary>
        ///  Unique identifier of the parent category.
        /// </summary>
        [Key]
        public uint ParentCategoryId { get; set; }
        
        /// <summary>
        /// Unique identifier of the category.
        /// </summary>
        public uint? CategoryId { get; set; }
        
        /// <summary>
        ///  Unique identifier of the subcategory.
        /// </summary>
        public uint? SubCategoryId { get; set; }
        
        /// <summary>
        ///  Name of the category.
        /// </summary>
        [Required]
        [MaxLength(31)]
        public string Name { get; set; }
        
        /// <summary>
        ///  Filters of the category.
        /// </summary>
        [InverseProperty("Category")]
        public List<FilterEf> Filters { get; set; } = new List<FilterEf>();
    }
}