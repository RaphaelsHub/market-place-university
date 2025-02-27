using System;
using System.Collections.Generic;
using ECommerce.Core.Enums.Entity;
using ECommerce.Core.Enums.User;

namespace ECommerce.Core.Models.DTOs.Blog
{
    public class BlogDto
    {
        public int? BlogId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateTimePublished { get; set; }
        public UserType UserPublished { get; set; }
        public EntityStatus EntityStatus { get; set; }
        public byte[] Image { get; set; }
        public List<MessageDto> Messages = new List<MessageDto>();
    }
}