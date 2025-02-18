using System;
using System.Collections.Generic;
using ECommerce.Core.Enums.User;

namespace ECommerce.Core.Entities.Blog
{
    public class BlogEf
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateTimePublished { get; set; } = DateTime.Now;
        public UserType UserPublished { get; set; }
        public byte[] Image { get; set; }
        
        public List<MessageEf> Comments{ get; set; } = new List<MessageEf>();
    }
}