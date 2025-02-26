using System.Collections.Generic;

namespace ECommerce.Core.Models.DTOs.Category
{
    public class CategoryDto
    {
        public int? CategoryId { get; set; } 
        public string Name { get; set; }
        public List<FilterDto> Filters { get; set; } = new List<FilterDto>();
    }
}