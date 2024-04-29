using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProject.Domain.Entities.User
{
    public class UserEF
    {
        //[Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public DateTime LogTime { get; set; }
        public DateTime RegTime { get; set; }
        // Навигационное свойство для указания на заказы пользователя
        //public ICollection<CartItem>? CartItems { get; set; } //текущие товары будущего заказа
        //public ICollection<Order>? Orders { get; set; } //уже выполненые заказы
    }
}
