using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProject.Core.Entities
{
    public class RattingEf
    {
        [Key]
        public uint RattingId { get; set; }
        public uint ProductId { get; set; }
        public uint Likes { get; set; }
        public uint Dislikes { get; set; }
        public uint Views { get; set; }
        
        [ForeignKey("ProductId")]
        public ProductEf Product { get; set; }
    }
}