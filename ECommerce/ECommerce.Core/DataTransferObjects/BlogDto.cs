using System;
using System.Collections.Generic;
using ECommerce.Core.Enums.User;

namespace ECommerce.Core.DataTransferObjects
{
    public class BlogDto
    {
        public uint Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<MessageDto> Messages { get; set; }
        public DateTime DateTimePublished { get; set; }
        public UserType UserPublished { get; set; }
    }
}