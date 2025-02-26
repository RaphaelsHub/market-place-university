using System;
using ECommerce.Core.Entities.User;
using ECommerce.Core.Enums.Entity;

namespace ECommerce.Core.Entities.Blog
{
    public class MessageEf
    {
        public int MessageId { get; set; }
        public string Content { get; set; } = "";
        public bool IsReplied { get; set; } = false;
        public DateTime DateSent { get; set; } = DateTime.Now;
        public EntityStatus Status { get; set; } = EntityStatus.Active;
        
        public int BlogId { get; set; }
        public BlogEf Blog { get; set; }
        
        public int UserSenderId { get; set; }
        public UserEf Sender { get; set; }

        public int? UserReceiverId { get; set; }
        public UserEf UserReceiver { get; set; }
    }
}