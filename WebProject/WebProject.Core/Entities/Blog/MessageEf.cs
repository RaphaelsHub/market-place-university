using System;
using WebProject.Core.Entities.User;
using WebProject.Core.Enums.Message;

namespace WebProject.Core.Entities.Blog
{
    public class MessageEf
    {
        public int MessageId { get; set; }
        public string Content { get; set; } = "";
        public DateTime DateSent { get; set; } = DateTime.Now;
        public MessageStatus Status { get; set; } = MessageStatus.Active;
        public bool IsReplied { get; set; } = false;
        
        public int? BlogId { get; set; }
        public BlogEf Blog { get; set; }
        
        public int UserSenderId { get; set; }
        public UserEf Sender { get; set; }

        public int? UserReceiverId { get; set; }
        public UserEf UserReceiver { get; set; }
    }
}