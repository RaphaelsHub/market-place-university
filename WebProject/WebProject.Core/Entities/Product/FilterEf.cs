using System.Collections.Generic;

namespace WebProject.Core.Entities.Product
{
    public class FilterEf
    {
        public uint FilterId { get; set; }
        public string FilterName { get; set; }
        public uint CategoryId { get; set; }
        public CategoryEf Category { get; set; }
        public List<FilterValueEf> FilterValues { get; set; } = new List<FilterValueEf>();
    }
}