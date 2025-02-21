using System;
using System.Collections.Generic;
using ECommerce.Core.Enums.Entity;
using ECommerce.Core.Enums.User;

namespace ECommerce.Core.Entities.Blog
{
    public class BlogEf
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public byte[] Image { get; set; }
        public UserType UserPublished { get; set; }  = UserType.Admin;
        public EntityStatus EntityStatus { get; set; } = EntityStatus.Active;
        public DateTime DateTimePublished { get; set; } = DateTime.Now;
        
        public List<MessageEf> Comments{ get; set; } = new List<MessageEf>();
    }
}