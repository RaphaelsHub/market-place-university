using System.Collections.Generic;

namespace ECommerce.Core.Models.DTOs.Category
{
    public class FilterDto
    {
        public int? FilterId { get; set; } 
        public string FilterName { get; set; }
        public List<FilterValueDto> FilterValues { get; set; } = new List<FilterValueDto>();

    }
}