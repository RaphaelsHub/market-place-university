using System.Collections.Generic;

namespace ECommerce.Core.Entities.Product
{
    public class FilterEf
    {
        public int FilterId { get; set; }
        public string FilterName { get; set; }
        public int CategoryId { get; set; }
        public CategoryEf Category { get; set; }
        public List<FilterValueEf> FilterValues { get; set; } = new List<FilterValueEf>();
    }
}