using System.Collections.Generic;

namespace ECommerce.Core.Entities.Product
{
    public class CategoryEf
    {
        public int ParentCategoryId { get; set; }
        public int? ChildCategoryId { get; set; }

        public string Name { get; set; }

        public List<FilterEf> Filters { get; set; } = new List<FilterEf>();
    }
}