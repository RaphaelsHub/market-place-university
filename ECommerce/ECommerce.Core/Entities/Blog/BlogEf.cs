using System;
using System.Collections.Generic;
using System.Linq;
using ECommerce.Core.Enums.Entity;
using ECommerce.Core.Enums.User;
using ECommerce.Core.Models.DTOs.Blog;

namespace ECommerce.Core.Entities.Blog
{
    public class BlogEf
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public byte[] Image { get; set; }
        public EntityStatus EntityStatus { get; set; } = EntityStatus.Active;
        public UserType UserPublished { get; private set; }  = UserType.Admin;
        public DateTime DateTimePublished { get; } = DateTime.Now;
        public List<MessageEf> Comments{ get; private set; } = new List<MessageEf>();
        
        public BlogEf(string title, string content, byte[] image)
        {
            Title = title;
            Content = content;
            Image = image;
        }
        public BlogEf(BlogDto blogDto)
        { 
            if(blogDto.BlogId.HasValue) BlogId = blogDto.BlogId.Value;
            Title = blogDto.Title;
            Content = blogDto.Content;
            Image = blogDto.Image;
        }
        
        public void SetEntityStatus(EntityStatus status) => EntityStatus = status;
        public void SetUserPublished(UserType userType) => UserPublished = userType;
        public void AddComment(MessageEf message) => Comments.Add(message);
        public void SetComments(List<MessageEf> comments) => Comments = comments;
        public List<MessageEf> GetComments() => Comments.OrderBy(x=>x.DateSent).ToList();
    }
}