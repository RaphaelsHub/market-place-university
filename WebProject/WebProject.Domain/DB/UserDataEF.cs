using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebProject.Domain.Enum;

namespace WebProject.Domain.DB
{
    public class UserDataEF
    {
        [Key]
        public int UserDataId { get; set; }
        public StatusUser StatusUser { get; set; } = StatusUser.Unknown; // Использование перечисления для статуса пользователя
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; } // Рассмотрите возможность хеширования пароля
        [Column(TypeName = "datetime2")]
        public DateTime LogTime { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime RegTime { get; set; }

        public ICollection<CartItemDataEF> CartItems { get; set; } = new List<CartItemDataEF>();
        public ICollection<OrderDataEF> Orders { get; set; } = new List<OrderDataEF>();
    }
}
