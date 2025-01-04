using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebProject.Core.Enums;

namespace WebProject.Core.Entities
{
    public class OrderEf
    {
        /// <summary>
        ///   Gets or sets the unique identifier for the order.
        /// </summary>
        [Key]
        public uint OrderId { get; set; }
        
        /// <summary>
        ///  Gets or sets the discount for the order.
        /// </summary>
        public float Discount { get; set; } = 0;
        
        /// <summary>
        /// Gets or sets the shipping price for the order.
        /// </summary>
        public decimal ShippingPrice { get; set; } = 0;
        
        /// <summary>
        /// Gets or sets the total price for the order.
        /// </summary>
        public decimal TotalPrice { get; set; } = 0;
        
        /// <summary>
        /// Gets or sets the final price for the order.
        /// </summary>
        public decimal FinalPrice { get; set; } = 0;
        
        /// <summary>
        /// Gets or sets the date when the order was placed.
        /// </summary>
        public DateTime DateOrdered { get; set; } = DateTime.Now;
        
        /// <summary>
        /// Gets or sets the date when the order was delivered.
        /// </summary>
        [NotMapped]
        private DateTime _dateTime = DateTime.Now;
        
        /// <summary>
        /// Gets or sets the date when the order was delivered.
        /// </summary>
        public DateTime DateDelivered
        {
            get => _dateTime;
            set
            {
                _dateTime = value;
                _dateTime = Status == OrderStatus.Delivered ? DateTime.Now : _dateTime;
            }
        }
        
        /// <summary>
        /// Gets or sets the status of the order.
        /// </summary>
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        
        /// <summary>
        ///  Gets or sets the list of product identifiers.
        /// </summary>
        public List<uint> ProductIds { get; set; }
        
        /// <summary>
        ///  Gets or sets the list of products.
        /// </summary>
        [Required]
        [Range(0, uint.MaxValue)]
        public uint UserId { get; set; }
        [ForeignKey("UserId")]
        public UserEf User { get; set; }
    }
}