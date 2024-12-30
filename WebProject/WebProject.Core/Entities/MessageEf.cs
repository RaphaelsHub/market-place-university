using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebProject.Core.Enums;

namespace WebProject.Core.Entities
{
    /// <summary>
    /// Represents a message entity.
    /// </summary>
    public class MessageEf
    {
        /// <summary>
        /// Gets or sets the unique identifier for the message.
        /// </summary>
        [Key]
        [Column("MessageId")]
        public uint MessageId { get; set; }

        /// <summary>
        /// Gets or sets the sender's user identifier.
        /// </summary>
        [Column("SenderId")]
        public uint SenderId { get; set; }

        /// <summary>
        /// Gets or sets the receiver's user identifier.
        /// </summary>
        [Column("ReceiverId")]
        public uint ReceiverId { get; set; }

        /// <summary>
        /// Gets or sets the content of the message.
        /// </summary>
        [Required]
        [StringLength(255, MinimumLength = 15, ErrorMessage = "Content must be between 15 and 255 characters")]
        [Column("Content")]
        public string Content { get; set; } = "";

        /// <summary>
        /// Gets or sets the date and time the message was sent.
        /// </summary>
        [Column("DateSent")]
        public DateTime DateSent { get; set; } = DateTime.Now;
        
        /// <summary>
        /// Gets or sets the status of the message.
        /// </summary>
        public MessageStatus Status { get; set; } = MessageStatus.Active;
        
        /// <summary>
        /// Gets or sets the sender user.
        /// </summary>
        [ForeignKey("SenderId")]
        public UserEf Sender { get; set; }

        /// <summary>
        /// Gets or sets the receiver user.
        /// </summary>
        [ForeignKey("ReceiverId")]
        public UserEf Receiver { get; set; }
    }

}