using System.Collections.Generic;

namespace ECommerce.Core.Entities.Product
{
    public class CategoryEf
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public List<FilterEf> Filters { get; set; } = new List<FilterEf>();
    }
}