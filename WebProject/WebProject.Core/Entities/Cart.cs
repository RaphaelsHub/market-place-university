namespace WebProject.Core.Entities
{
    public class Cart
    {
        public uint UserId { get; set; }
        public uint ProductId { get; set; }
        public uint Quantity { get; set; }
    }
}