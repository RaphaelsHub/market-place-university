using System.Collections.Generic;

namespace WebProject.Core.Entities
{
    public class FilterEf
    {
        public uint FilterId { get; set; }
        public uint CategoryId { get; set; }
        public string Name { get; set; }
        public List<FilterValueEf> FilterValues { get; set; } = new List<FilterValueEf>();
    }
}