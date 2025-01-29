using System;
using WebProject.Core.Enums.Message;

namespace WebProject.Core.DTO
{
    public class MessageDto
    {
        public uint MessageId { get; set; }
        public string Content { get; set; }
        public DateTime DateSent { get; set; }
        public MessageStatus Status { get; set; }
        public bool IsReplied { get; set; } = false;
        public uint? BlogId { get; set; }
        public uint UserSenderId { get; set; }
        public uint? UserReceiverId { get; set; }
    }
}