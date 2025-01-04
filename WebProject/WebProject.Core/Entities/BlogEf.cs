using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProject.Core.Entities
{
    public class BlogEf
    {
        /// <summary>
        ///   The primary key of the blog.
        /// </summary>
        [Key]
        public uint BlogId { get; set; }
        
        /// <summary>
        ///  The title of the blog.
        /// </summary>
        [Required]
        [MaxLength(15)]
        public string Title { get; set; }
        
        /// <summary>
        ///  The content of the blog.
        /// </summary>
        [Required]
        [MaxLength(511)]
        public string Content { get; set; }
        
        /// <summary>
        ///  The date the blog was posted.
        /// </summary>
        public DateTime DatePosted { get; set; } = DateTime.Now;
        
        /// <summary>
        ///  The image of the blog.
        /// </summary>
        [Required]
        public string Image { get; set; }
        
        /// <summary>
        ///  The user who posted the blog.
        /// </summary>
        [InverseProperty("Blog")]
        public List<MessageEf> Comments{ get; set; } = new List<MessageEf>();
    }
}