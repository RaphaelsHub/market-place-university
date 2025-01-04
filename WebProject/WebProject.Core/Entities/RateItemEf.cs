using System.ComponentModel.DataAnnotations.Schema;

namespace WebProject.Core.Entities
{
    public class RateItemEf
    {
        public uint RateItemId { get; set; }
        
        public uint FullName { get; set; }
        
        public float Rate { get; set; } = 0;
        
        public string Comment { get; set; }
        
        public uint UserId { get; set; }
        [ForeignKey("UserId")]
        public UserEf User { get; set; }
        
        public uint ProductId { get; set; }
        [ForeignKey("ProductId")]
        public ProductEf Product { get; set; }
    }
}