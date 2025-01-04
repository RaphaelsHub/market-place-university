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
        public uint MessageId { get; set; }

        /// <summary>
        ///  Gets or sets the content of the message.
        /// </summary>
        [Required]
        [StringLength(255, MinimumLength = 15)]
        public string Content { get; set; } = "";
        
        /// <summary>
        /// Gets or sets the date and time the message was sent.
        /// </summary>
        public DateTime DateSent { get; set; } = DateTime.Now;
        
        /// <summary>
        /// Gets or sets the status of the message.
        /// </summary>
        public MessageStatus Status { get; set; } = MessageStatus.Active;
        
        /// <summary>
        /// Gets or sets the value indicating whether the message was replied. 
        /// </summary>
        public bool IsReplied { get; set; } = false;
        
        /// <summary>
        ///  Gets or sets the blog identifier.
        /// </summary>
        public uint? BlogId { get; set; }
        [ForeignKey("BlogId")]
        public BlogEf Blog { get; set; }
        
        /// <summary>
        /// Gets or sets the sender's user identifier.
        /// </summary>
        [Required]
        [Range(0, uint.MaxValue)]
        public uint UserSenderId { get; set; }
        [ForeignKey("UserSenderId")]
        public UserEf Sender { get; set; }

        /// <summary>
        /// Gets or sets the receiver's user identifier.
        /// uint? is used to allow null values, as the message can be sent to all users.
        /// </summary>
        public uint? UserReceiverId { get; set; }
        [ForeignKey("UserReceiverId")]
        public UserEf UserReceiver { get; set; }
    }
}