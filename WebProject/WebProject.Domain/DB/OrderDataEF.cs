using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebProject.Domain.Enum;

namespace WebProject.Domain.DB
{
    public class OrderDataEF
    {
        [Key]
        public int OrderDataId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string Comment { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime OrderDate { get; set; } = DateTime.Now;

        public StatusDelivery StatusDelivery { get; set; } = StatusDelivery.Pending;

        public ICollection<CartItemDataEF> CartItems { get; set; } = new List<CartItemDataEF>();


        public int UserDataId { get; set; } //внешний ключ для доступа к userdataEf

        [ForeignKey("UserDataId")]
        public UserDataEF User { get; set; }
    }
}
