using System.Collections.Generic;

namespace WebProject.Core.Entities
{
    public class CategoryEf
    {
        public uint CategoryId { get; set; }
        public uint SubCategoryId { get; set; }
        public uint ParentCategoryId { get; set; }
        public string Name { get; set; }
        public List<FilterEf> Filters { get; set; } = new List<FilterEf>();
    }
}