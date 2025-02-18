using System;
using ECommerce.Core.Enums.Entity;
using ECommerce.Core.Enums.User;

namespace ECommerce.Core.Models.DTOs.Blog
{
    public class BlogDto
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateTimePublished { get; set; } = DateTime.Now;
        public UserType UserPublished { get; set; }
        public EntityStatus EntityStatus { get; set; } = EntityStatus.Inactive;
        public byte[] Image { get; set; }
    }
}