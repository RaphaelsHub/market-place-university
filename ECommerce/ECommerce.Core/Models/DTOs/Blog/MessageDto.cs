using System;
using ECommerce.Core.Enums.Entity;

namespace ECommerce.Core.Models.DTOs.Blog
{
    public class MessageDto
    {
        public uint MessageId { get; set; }
        public string Content { get; set; }
        public DateTime DateSent { get; set; }
        public EntityStatus Status { get; set; }
        public bool IsReplied { get; set; }
        public uint BlogId { get; set; }
        public uint UserSenderId { get; set; }
        public uint? UserReceiverId { get; set; }
    }
}