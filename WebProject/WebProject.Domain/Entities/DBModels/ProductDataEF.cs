using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Domain.Entities.User;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;



namespace WebProject.Domain.Entities.DBModels
{
    public class ProductDataEF
    {
        [Key]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int AdminId { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public string PhotoUrls { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }

        // Навигационное свойство для связи с категорией товара
        [ForeignKey("CategoryId")]
        public virtual CategoryTypeEF Category { get; set; }


        [ForeignKey("AdminId")]
        public virtual UserEF Owner { get; set; }
    }
}
