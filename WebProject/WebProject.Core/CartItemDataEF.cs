using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProject.Domain.DB
{
    public class CartItemDataEF
    {
        [Key]
        public int CartItemId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public int UserDataId { get; set; } // Внешний ключ для связи с UserDataEF

        [ForeignKey("UserDataId")]
        public UserDataEF User { get; set; } // Навигационное свойство для пользователя, которому принадлежит элемент корзины
    }
}


