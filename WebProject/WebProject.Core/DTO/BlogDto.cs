using System;
using System.Collections.Generic;
using WebProject.Core.Enums;
using WebProject.Core.Enums.User;

namespace WebProject.Core.DTO
{
    public class BlogDto
    {
        public uint Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<string> Tags { get; set; }
        public List<string> Messages { get; set; }
        public DateTime DateTimePublished { get; set; }
        public UserType UserType { get; set; } = UserType.Moderator;
    }
}