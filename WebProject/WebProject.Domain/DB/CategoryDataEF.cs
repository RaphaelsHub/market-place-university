using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProject.Domain.DB
{
    public class CategoryDataEF
    {
        [Key]
        public int CategoryDataId { get; set; }

        public string CategoryName { get; set; }

        public int? ParentCategoryId { get; set; }

        [ForeignKey("ParentCategoryId")]
        public virtual CategoryDataEF ParentCategory { get; set; }

        public virtual ICollection<CategoryDataEF> ChildCategories { get; set; } = new List<CategoryDataEF>();
    }
}
