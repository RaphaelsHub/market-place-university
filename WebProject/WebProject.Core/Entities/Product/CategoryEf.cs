using System.Collections.Generic;

namespace WebProject.Core.Entities.Product
{
    public class CategoryEf
    {
        public uint ParentCategoryId { get; set; }
        public uint? ChildCategoryId { get; set; }

        public string Name { get; set; }

        public List<FilterEf> Filters { get; set; } = new List<FilterEf>();
    }
}