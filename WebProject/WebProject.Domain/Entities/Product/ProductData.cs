using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProject.Domain.Entities.Product
{
    public class ProductData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public string PhotoUrls { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }

        // Навигационное свойство для связи с категорией товара
        public int CategoryId { get; set; }
        //[ForeignKey("CategoryId")]
        //public virtual CategoryTypeData Category { get; set; }
    }
}
