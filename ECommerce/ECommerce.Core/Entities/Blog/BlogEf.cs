using System;
using System.Collections.Generic;

namespace ECommerce.Core.Entities.Blog
{
    public class BlogEf
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DatePosted { get; set; } = DateTime.Now;
        public byte[] Image { get; set; }
        
        public List<MessageEf> Comments{ get; set; } = new List<MessageEf>();
    }
}